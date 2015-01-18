import java.io.*;
import java.util.*;

public class FileHelper
{
	public static void ensureFilePath(String path)
	{
		File file = new File(path);

		File parentFile = new File(file.getAbsoluteFile().getParent());

		parentFile.mkdirs();
	}
	
	public static void ensureDirPath(String path)
	{
		File file = new File(path);

		file.mkdirs();
	}
	
	public static String uniqueFilePath(String path)
	{
		File f = new File(path);
		//String uniquePath = path;
		
		File newFile = f;
		int i=0;
		String newDir;
		while(newFile.exists())
		{
			File parentDir = new File(f.getParent());
			newDir = parentDir.getAbsolutePath() + "_" + Integer.toString(i) + "\\" + f.getName();
			newFile = new File(newDir);
		}
		
		String newPath = newFile.getAbsolutePath();
		System.out.println(newPath + ": for :" + path);
		return newPath;
	}
	
	public static void copyFile(String sourcePath, String destPath) throws IOException {
 		File oldLocation = new File(sourcePath);
		//File newLocation = new File(destPath); 
		
        if ( oldLocation.exists( )) {
            BufferedInputStream  reader = new BufferedInputStream( new FileInputStream(sourcePath) );
            BufferedOutputStream  writer = new BufferedOutputStream( new FileOutputStream(destPath, false));
            try {
                byte[]  buff = new byte[Config.Instance().bufferSize];
                int numChars;
                while ( (numChars = reader.read(  buff, 0, buff.length ) ) != -1) {
                    writer.write( buff, 0, numChars );
                }
            } catch( IOException ex ) {
                throw new IOException("IOException when transferring " + sourcePath + " to " + destPath);
            } finally {
                try {
                    if ( reader != null ){                      
                        writer.close();
                        reader.close();
                    }
                } catch( IOException ex ){
                    Logger.Instance().Write(3, "Error closing files when transferring " + sourcePath + " to " + destPath ); 
                }
            }
        } else {
            throw new IOException("Old location does not exist when transferring " + sourcePath + " to " + destPath );
        }
    }

	public static String getFileExtension(String name) {
		//String name = file.getName();
		int lastIndexOf = name.lastIndexOf(".");
		if (lastIndexOf == -1) {
			return ""; // empty extension
		}
		return name.substring(lastIndexOf+1);
	}


}