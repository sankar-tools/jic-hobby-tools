import java.io.File;
import javax.swing.JFileChooser;
import javax.swing.filechooser.FileSystemView;

import java.util.*;


public class ScanFiles implements Runnable
{

	public void init()
	{
/* 		Config cfg = Config.Instance();		

		for(int i=0; i<cfg.skipDirs.size(); i++)
		{
			System.out.println(cfg.skipDirs.get(i));
		} */
		addFileRoots();
		addSpecialFolders();
	}
	
	public void run( )
	{
		// run directory scan for each item in the parseDirs
		Config cfg = Config.Instance();
		Logger log = Logger.Instance();
		
		log.Write(3, "File scanning started at " + new Date().toString());
		
		for(int i=0; i<cfg.parseDirs.size(); i++)
		{
			String scanPath = cfg.parseDirs.get(i);
			log.Write(3, "Scanning dir: " + scanPath);
			getFilesRecursive(scanPath);
			log.Write(3, "Total files found " + Long.toString(FileStore.fileCounter));
		}
		
		FileStore.scanComplete = true;
		
		log.Write(3, "Total files found " + Long.toString(FileStore.fileCounter));
		log.Write(3, "File scanning ended at " + new Date().toString());
	}
	
	public void getFilesRecursive(String path)
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
				//String thisDir = f.getName();
				boolean skipDir = skipThisDir(f.getAbsolutePath());
				// skip if it is config skipDirs
				if(skipDir == false)
				{
					// skip if already in the queue
					boolean duplicateDir = isDuplicateInQueue(f.getAbsolutePath());
					if(duplicateDir == false)
					{
						log.Write(3, "[ok]  " + f.getAbsolutePath());
						getFilesRecursive(f.getAbsolutePath());
					}
					else
						log.Write(3, "[dup]   " + f.getAbsolutePath());
				}
				else
					log.Write(3, "[skip]  " + f.getAbsolutePath());
			}
			else {
				//if file extension is part of Config FileExtList then add to queue
				String ext = FileHelper.getFileExtension(f.getName());
				if(cfg.fileExtList.toUpperCase().lastIndexOf(ext.toUpperCase()) > -1)
				{
					// check file min size
					if(f.length() > (cfg.minSizeKb * 1000))
					{
						log.Write(1, f.getAbsolutePath());
						FileStore.Files.enqueue(f.getAbsolutePath());
						fileCount++;
						FileStore.fileCounter++;
						//System.out.println(f.getAbsoluteFile()  + "    " + Double.toString(f.length()));
					}
				}
			}
		}
		
		log.Write(1, "Added file(s) : " + Integer.toString(fileCount) + " for dir " + path + ". Queue size " + Integer.toString(FileStore.Files.size()));
	}
	
	private void addFileRoots()
	{
		Config cfg = Config.Instance();
		Logger log = Logger.Instance();
		
		File[] roots;
		FileSystemView fsv = FileSystemView.getFileSystemView();

		// returns pathnames for files and directory
		roots = File.listRoots();

		// for each pathname in pathname array
		int i;
		for(i = 0; i < roots.length ; i++)
		{
			// prints file and directory paths
			log.Write(3, "Drive Name: "+ roots[i].getAbsolutePath());
			cfg.parseDirs.enqueue(roots[i].getAbsolutePath());

			// ToDo :: Filter CD Drives and other removable media
			
			//ToDo:: Add root directories
		}
	}
	
	private void addSpecialFolders()
	{
		//ToDo: Iterate special folders
	}
	
	private boolean skipThisDir(String dir)
	{
		Config cfg = Config.Instance();		
		dir = dir.toUpperCase();
		//System.out.println("Verify " + dir);
		for(int i=0; i<cfg.skipDirs.size(); i++)
		{
			//System.out.println(cfg.skipDirs.get(i));
			if(cfg.skipDirs.get(i).equals(dir))
			{
				//System.out.println("skip");
				return true;

			}
		}
		//System.out.println("include");
		return false;
	}
	
	private boolean isDuplicateInQueue(String dir)
	{
		Config cfg = Config.Instance();		
		dir = dir.toUpperCase();
		System.out.println("Verify " + dir);
		for(int i=0; i<cfg.parseDirs.size(); i++)
		{
			System.out.println("Listed " + cfg.parseDirs.get(i));
			if(cfg.parseDirs.get(i).equals(dir))
			{
				System.out.println("skip");
				return true;
			}
		}
		System.out.println("include");
		return false;
	}	
}