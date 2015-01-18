import java.util.*;

public class Config
{

	public String fileExtList;
	public String storePath;
	public String logFile;
	public String authUser;
	public String authCode;
	public Queue parseDirs;
	public LinkedList skipDirs;
	public boolean scanAllDirs;
	public boolean scanOnly;
	public boolean showUI;
	public long minSizeKb;
	public int bufferSize;
	
	private static Config configData = null;
	
	private Config()
	{}
	
	public static Config Instance()
	{
		if (configData == null)
		{
			configData = new Config();
			configData.loadConfig();
		}

		return configData;
	}
	
	
	private void loadConfig()
	{
		configData.parseDirs = new Queue();
		
		LinkedList skipDirsList = new LinkedList();
		skipDirsList.add("c:\\program files".toUpperCase());
		skipDirsList.add("c:\\program files (x86)".toUpperCase());
		skipDirsList.add("c:\\programdata".toUpperCase());
		skipDirsList.add("c:\\boot".toUpperCase());
		skipDirsList.add("c:\\bPowerTemp".toUpperCase());
		skipDirsList.add("c:\\Config.Msi".toUpperCase());
		skipDirsList.add("c:\\Windows".toUpperCase());
		skipDirsList.add("c:\\winnt".toUpperCase());
		skipDirsList.add("c:\\win".toUpperCase());
		skipDirsList.add("d:\\BIN".toUpperCase());
		skipDirsList.add("C:\\jdk1.2.2".toUpperCase());
		skipDirsList.add("c:\\IBM".toUpperCase());
		
		
		configData.skipDirs = skipDirsList;
		
		
		configData.fileExtList = "jpg;png";
		configData.storePath = ".\\store\\";
		configData.logFile = "this.log";
		configData.authUser = "sans";
		configData.authCode = "sans";
		configData.scanAllDirs = true;
		configData.scanOnly = true;
		configData.minSizeKb = 150;
		configData.bufferSize = 8192;
		
	}
	
	
}