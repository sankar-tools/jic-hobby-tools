import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

public class Splash {

	JFrame splashFrame=null;

	public void show(){
		createSlashFrame();
		designLayout();
		
		// This is an empty content area in the frame

		splashFrame.pack();

	}
	
	protected void createSlashFrame()
	{
		splashFrame = new JFrame("SecureDisc");
		splashFrame.getContentPane().setBackground(new Color(255,255,255));
		
		// Add a window listner for close button
		splashFrame.addWindowListener(new WindowAdapter() {
			public void windowClosing(WindowEvent e) {
				System.exit(0);
			}
		});
		
		splashFrame.setSize(new Dimension(400,600));
		//splashFrame.setResizable(false);
		splashFrame.setVisible(true);
	}
	
	protected void designLayout()
	{
		splashFrame.getContentPane().setLayout(new GridLayout());
		
		//Add top image
		
		//Add left image
		ImagePanel panel = new ImagePanel(new ImageIcon("usblock.bmp").getImage());
		panel.setBounds(40,40,200,500);
		splashFrame.getContentPane().add(panel);
		
		
		//Add copyright image
		JLabel lblCopyright = new JLabel("");
		lblCopyright.setText("Copyright SecureDisc (c) 2014. All rights reserved");
		lblCopyright.setPreferredSize(new Dimension(175, 100));
		lblCopyright.setBounds(10,10,20,50);
		splashFrame.getContentPane().add(lblCopyright);
		
	}
	

}