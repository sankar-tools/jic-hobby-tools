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
						FileHelper.ensureFilePath(destFilePath);

						FileHelper.copyFile(sourceFilePath, destFilePath);
						log.Write(2, sourceFilePath + " saved to " + destFilePath);
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
		String path = storePath + "\\" + filePath.replace(':', '\\');

		// ToDo:: Logic if path > 255 chars
		
		return path;
	}
}	