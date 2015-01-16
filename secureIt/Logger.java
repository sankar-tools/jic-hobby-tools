import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class Logger
{	
	private BufferedWriter saveLoggerFile = null;
	private BufferedWriter scanLoggerFile = null;
	private BufferedWriter genericLoggerFile = null;
		
	private static Logger logInstance = null;
	
	private Logger()
	{
		Config cfg = Config.Instance();
		
		String saveLogPath = cfg.StorePath + "\\" + "todo" + "\\save_" + cfg.LogFile;
		String scanLogPath = cfg.StorePath + "\\" + "todo" + "\\scan_" + cfg.LogFile;
		String genericLogPath = cfg.StorePath + "\\" + "todo" + "\\generic_" + cfg.LogFile;
		System.out.println(saveLogPath);
		
		saveLoggerFile = GetBufferedWriter(saveLogPath);
		scanLoggerFile = GetBufferedWriter(scanLogPath);
		genericLoggerFile = GetBufferedWriter(genericLogPath);
	}
	
	private BufferedWriter GetBufferedWriter(String path)
	{
		BufferedWriter bw = null;
		try {
			File file = new File(path);

			//file.mkdirs();
			if (!file.exists()) {
				file.createNewFile();
			}

			FileWriter fw = new FileWriter(file.getAbsoluteFile());
			bw = new BufferedWriter(fw);
			

		} catch (IOException e) {
			e.printStackTrace();
		}
		
		return bw;
	}
	
	public static Logger Instance()
	{
		if (logInstance == null)
			logInstance = new Logger();

		return logInstance;
	}
	
	public void Write(int module, String msg)
	{
		String logMsg = module + " :: " +  msg;
		System.out.println(logMsg);
		try {
			switch (module)
			{
				case 1:
					scanLoggerFile.write(msg);
					scanLoggerFile.flush();
					break;

				case 2:
					saveLoggerFile.write(msg);
					saveLoggerFile.flush();
					break;

				default:
					genericLoggerFile.write(logMsg);
					genericLoggerFile.flush();
					break;
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}




