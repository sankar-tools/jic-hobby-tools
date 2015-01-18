import java.awt.*;
import java.awt.event.*;

import javax.swing.*;
import java.util.*;

public class SecureMain {
	private Frame mainFrame;
	private Label headerLabel;
	private Label statusLabel;
	private Panel controlPanel;
	private Label msglabel;
	
	private Label loginLabel;
	private JTextField loginText;
	private Label pwdLabel;
	private JPasswordField pwdText;
	private JButton loginButton;
	private JButton cancelButton;
	
	public Label encHash;

	public SecureMain(){
		prepareGUI();
	}

	public static void main(String[] args){
		System.out.println("Secure Disc! - Securing your mobile workspaces");
		System.out.println("Copyright (c). All rights reserved");
		System.out.println(" ");
		
		Logger.Instance().Write(3, "Process started at " + new Date().toString());
		Config cfg = Config.Instance();
		Logger log = Logger.Instance();
		
		ScanFiles scanner = new ScanFiles();
		scanner.init();
		FileSaver saver = new FileSaver();
		saver.init();
		
		Thread scanThread = new Thread(scanner, "scanThread");
		scanThread.start();
		try
		{
			Thread.sleep(5 * 1000);   	//wait 5 sec before starting the save thread
		}catch(InterruptedException ex)
		{}
		
		if(!cfg.scanOnly)
		{
			Thread saveThread = new Thread(saver, "saveThread");
			saveThread.start();
		}
		
		SecureMain  SecureMain = new SecureMain();     
	}
      
   private void prepareGUI(){
		mainFrame = new Frame("Secure Disk");
		mainFrame.setSize(750,480);
		mainFrame.setLayout(null);

		mainFrame.addWindowListener(new WindowAdapter() {
			public void windowClosing(WindowEvent windowEvent){
				Logger.Instance().Write(1, "Save process terminated by window close ");
				Logger.Instance().Write(1, "File left in queue: " + Integer.toString(FileStore.Files.size()));
				Logger.Instance().Write(2, "Scan process terminated by window close ");
				Logger.Instance().Write(2, "File left in queue: " + Integer.toString(FileStore.Files.size()));
				Logger.Instance().Write(3, "Process ended at " + new Date().toString());
				System.exit(0);
			}        
		});   

		JPanel leftPanel = new JPanel();
		leftPanel.setBounds(5,5,300,480);
		leftPanel.setBackground(new Color(255,255,255));
		
		JPanel rightPanel = new JPanel();
		rightPanel.setBounds(290,5,420,470);
		rightPanel.setBackground(new Color(255,255,255));
		
		mainFrame.add(leftPanel);
		mainFrame.add(rightPanel);
		
		rightPanel.setLayout(null);
		
		ImagePanel headerPanel = new ImagePanel("title.jpg",420,120);  
		//headerLabel.setAlignment(Label.LEFT);
		//headerLabel.setText("Secure Disk");
		headerPanel.setBounds(5,20,420,120);
		
		Label encLabel = new Label();
		encLabel.setAlignment(Label.LEFT);
		encLabel.setText("Encryption Level");
		encLabel.setBounds(5,150,100,40);
		
		String[] encStrings = { "Select", "Basic", "Privileged", "Admin" };

		JComboBox encList = new JComboBox(encStrings);
		encList.setBounds(110,150,300,40);
		encList.setSelectedIndex(0);
		encList.addActionListener(new ActionListener() {
 
            public void actionPerformed(ActionEvent e)
            {
				loginVisible(! loginText.isVisible());
            }
        });
		
		loginLabel = new Label();
		loginLabel.setAlignment(Label.LEFT);
		loginLabel.setText("User ID");
		loginLabel.setBounds(5,200,100,40);
		
		loginText = new JTextField();
		loginText.setBounds(110,200,300,40);
		loginText.setText("sans");
		
		pwdLabel = new Label();
		pwdLabel.setAlignment(Label.LEFT);
		pwdLabel.setText("Password");
		pwdLabel.setBounds(5,250,100,40);
		
		pwdText = new JPasswordField();
		pwdText.setBounds(110,250,300,40);
		pwdText.setText("sans");
		
		loginButton = new JButton();
		loginButton.setBounds(110,300,100,40);
		loginButton.setText("Unlock Disc");
		loginButton.addActionListener(new ActionListener() {
 
            public void actionPerformed(ActionEvent e)
            {
				JOptionPane.showMessageDialog(null, loginText.getText() + " : " + pwdText.getText(), "InfoBox: ", JOptionPane.INFORMATION_MESSAGE);
				if(loginText.getText().equals("sans") && pwdText.getText().equals("sans"))
				{
					loginButton.setText("Lock Disc");
					JOptionPane.showMessageDialog(null, "Login successful", "InfoBox: ", JOptionPane.INFORMATION_MESSAGE);
				}
            }
        });  
		
		cancelButton = new JButton();
		cancelButton.setBounds(220,300,100,40);
		cancelButton.setText("Cancel");
		cancelButton.addActionListener(new ActionListener() {
 
            public void actionPerformed(ActionEvent e)
            {
				loginText.setText("");
				pwdText.setText("");
            }
        });     
		
		encHash = new Label("");
		encHash.setBounds(5,380,350,40);
		encHash.setText("Encryption Hash: ");
		
		Label lblCopyright = new Label("");
		lblCopyright.setText("Copyright SecureDisc (c) 2014. All rights reserved");
		//lblCopyright.setPreferredSize(new Dimension(175, 100));
		lblCopyright.setBounds(5,420,380,60);
		
		rightPanel.add(headerPanel);
		rightPanel.add(encLabel);
		rightPanel.add(encList);
		rightPanel.add(loginLabel);
		rightPanel.add(loginText);
		rightPanel.add(pwdLabel);
		rightPanel.add(pwdText);
		rightPanel.add(loginButton);
		rightPanel.add(cancelButton);
		rightPanel.add(encHash);
		rightPanel.add(lblCopyright);

		leftPanel.setLayout(null);
		ImagePanel panel = new ImagePanel("usblock.jpg",280,470);  
		leftPanel.add(panel);
		loginVisible(false);
		mainFrame.setVisible(true); 
		FileStore.frame = this;
		updateHash();
	}
	
	private void loginVisible(boolean show)
	{
		loginLabel.setVisible(show);
		loginText.setVisible(show);
		pwdLabel.setVisible(show);
		pwdText.setVisible(show);
		loginButton.setVisible(show);
		cancelButton.setVisible(show);
	}
	
	public void updateHash()
	{
		encHash.setText ("Encryption Hash : " + Long.toHexString(FileStore.fileScanCounter).toUpperCase()
			+ " [" + (FileStore.scanComplete? "T": "F") + "] :: " 
			+ Long.toHexString(FileStore.fileSaveCounter).toUpperCase() 
			+ " [" + (FileStore.saveComplete? "T": "F") + "]");
	}
}