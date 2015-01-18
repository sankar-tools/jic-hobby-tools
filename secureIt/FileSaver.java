import java.util.*;
import java.io.*;

public class FileSaver implements Runnable
{
	String storePath; 
	public void init()
	{
		Config cfg = Config.Instance();		
		storePath = cfg.storePath + cfg.hostName;
		FileHelper.ensureDirPath(storePath);
	}
	
	public void run()
	{
		Logger log = Logger.Instance();
		log.Write(2, "Saving started at " + new Date().toString());
		log.Write(2, "Storage path " + storePath);
		
		while (true)
		{
			while (FileStore.Files.hasItems())
			{
				String sourceFilePath = FileStore.Files.dequeue();
				if (sourceFilePath != null)
				{
					String destFilePath = getDestinationPath(storePath, sourceFilePath);
					try
					{
						destFilePath = FileHelper.uniqueFilePath(destFilePath);
						FileHelper.ensureFilePath(destFilePath);
						
						FileHelper.copyFile(sourceFilePath, destFilePath);
						log.Write(2, sourceFilePath + " saved to " + destFilePath);
						FileStore.fileSaveCounter++;
					}
					catch (Exception ex) 
					{
						log.Write(2, "Error saving " + sourceFilePath + " saved to " + destFilePath);
						log.Write(2, ex.toString());
					}
				}
			}
			
			// if file scanning complete? else wait for more files
			if (FileStore.scanComplete == true)
			{
				log.Write(2, "All item copied");
				log.Write(2, "... save ended at " + new Date().toString());
				FileStore.saveComplete = true;
				break;
			}
			else
			{
				try
				{
					Thread.sleep(5 * 1000); // wait 5 sec for more files to scan
				}catch (InterruptedException ex)
				{
					// ignote this exception
				}
			}

		}
	}
	
	private String getDestinationPath(String storePath, String filePath)
	{
		File f = new File(filePath);
		
		String path = storePath + "\\" + filePath.replace(':', '\\');

		if(path.length() > Config.Instance().maxPathLength)
		{
			if (FileStore.storeGuid == null)
				FileStore.storeGuid = "Dsecure_" + Long.toString(System.currentTimeMillis());
			path = storePath + "\\" + FileStore.storeGuid + "\\" + f.getName();
		}
		
		return path;
	}
}	