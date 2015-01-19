import java.util.*;
import java.awt.*;
import java.awt.event.*;

import javax.swing.*;


class FileStore
{
	public static Queue Files = new Queue();
	public static boolean scanComplete = false;
	public static boolean saveComplete = false;
	public static long fileScanCounter = 0;
	public static long fileSaveCounter = 0;
	public static String storeGuid = null;
	
	public static boolean loggedIn = false;
	
	public static SecureMain frame = null;
}