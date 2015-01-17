import java.io.File;
import javax.swing.JFileChooser;
import javax.swing.filechooser.FileSystemView;

import java.util.*;


public class ScanFiles implements Runnable
{

	public void init()
	{
		addFileRoots();
		addSpecialFolders();
	}
	
	public void run( )
	{
		// run directory scan for each item in the parseDirs
		Config cfg = Config.Instance();
		
		while(cfg.parseDirs.hasItems())
		{
			getFilesRecursive(cfg.parseDirs.dequeue());
		}	
	}
	
	public static void getFilesRecursive(String path)
	{
		Config cfg = Config.Instance();
		Logger log = Logger.Instance();
		
		File root = new File( path );
		File[] list = root.listFiles();

		if (list == null) return;

		int fileCount = 0;
		for (int i=0; i<list.length; i++ ) {
			File f = list[i];
			if ( f.isDirectory() ) {
				getFilesRecursive( f.getAbsolutePath());
				//System.out.println( "Dir:" + f.getAbsoluteFile() );
			}
			else {
				//if file extension is part of Config FileExtList then add to queue
				String ext = FileHelper.getFileExtension(f.getName());
				if(cfg.fileExtList.lastIndexOf(ext) > -1)
				{
					log.Write(1, f.getAbsolutePath());
					FileStore.Files.enqueue(f.getAbsolutePath());
					fileCount++;
					//System.out.print("[ok]");
				}
				else
				{
					//System.out.print("[xx]");
				}
					
				System.out.println( "     File:" + f.getAbsoluteFile()  + "    " + ext);
			}
		}
		
		log.Write(1, "Added file(s) : " + Integer.toString(fileCount) + " for dir " + path + ". Queue size " + Integer.toString(FileStore.Files.size()));
	}
	
	private void addFileRoots()
	{
		Config cfg = Config.Instance();
		File[] roots;
		FileSystemView fsv = FileSystemView.getFileSystemView();

		// returns pathnames for files and directory
		roots = File.listRoots();

		// for each pathname in pathname array
		int i;
		for(i = 0; i < roots.length ; i++)
		{
			// prints file and directory paths
			System.out.println("Drive Name: "+roots[i]);
			cfg.parseDirs.enqueue(roots[i].getAbsolutePath());
			//System.out.println("Description: "+fsv.getSystemTypeDescription(roots[i]));
		}
	}
	
	private void addSpecialFolders()
	{
		//ToDo: Iterate special folders
	}
	
}