import java.awt.Dimension;  
import java.awt.Graphics;  
import java.awt.Image;  
  
import javax.swing.ImageIcon;  
import javax.swing.JFrame;  
import javax.swing.JPanel;  

class ImagePanel extends JPanel {  

	private Image img;  

	public ImagePanel(String img, int width, int height) {  
		this(new ImageIcon(img).getImage(), width, height);  
	}  

	public ImagePanel(Image img, int width, int height) {  
		this.img = img;  
		Dimension size = new Dimension(width, height);  
		setPreferredSize(size);  
		setMinimumSize(size);  
		setMaximumSize(size);  
		setSize(size);  
		setLayout(null);  
	}  

	public void paintComponent(Graphics g) {  
		g.drawImage(img, 0, 0, null);  
	}  


	public static void main(String[] args) {  
		ImagePanel panel = new ImagePanel("usblock.jpg",200,200);  
		//panel.setBounds(5,5,300,300);
		//panel.setVisible(true);

		JFrame frame = new JFrame();  
		frame.getContentPane().setLayout(null);

		frame.getContentPane().add(panel);  
		frame.setSize(700,400);
		frame.pack();  
		frame.setVisible(true);  
	}  

}  