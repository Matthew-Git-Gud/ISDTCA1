using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

public class GameOver : MonoBehaviour
{

    public Slider healthbar;
    public GameObject WinPanelEscaped;
    public GameObject WinPanelFire;
    public GameObject LosePanelFire;
    public GameObject LosePanelSmoke;
    public GameObject[] Fire;
    private AudioSource[] allAudioSources;
    private string excelName;
    private string timeStamp;
    private string ending;
    DateTime dt = DateTime.Now;

    public void Start()
    {
        Time.timeScale = 1f;
        PlayAllAudio();
        GameStart();
    }

    void OnTriggerEnter(Collider collider)
    {
        // Checks if object it collides with is a player
        // Win Condition
        if (collider.gameObject.tag == "Door")
        {
            StartCoroutine(EscapeWin());
        }
        //Lose Condition
        if (collider.gameObject.tag == "Fire")
        {
            StartCoroutine(LostFire());
        }
    }

    IEnumerator EscapeWin()
    {
        yield return new WaitForSecondsRealtime(1);
        WinPanelEscaped.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        StopAllAudio();
        
        ending = "Escaped Ending";
        SaveEntry();
    }

    IEnumerator FireWin()
    {
        yield return new WaitForSecondsRealtime(1);
        WinPanelFire.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        StopAllAudio();

        ending = "Extinguished Fire Ending";
        SaveEntry();
    }

    IEnumerator LostFire()
    {
        yield return new WaitForSecondsRealtime(0);
        LosePanelFire.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        StopAllAudio();

        ending = "Died to Fire Ending";
        SaveEntry();
    }

    IEnumerator LostSmoke()
    {
        yield return new WaitForSecondsRealtime(0);
        LosePanelSmoke.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        StopAllAudio();

        ending = "No Oxygen Ending";
        SaveEntry();
    }

    void PlayAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Play();
        }
    }

    void StopAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
    }

    void GameStart(){

        excelName = dt.ToString("yyyy-MM-dd") + ".xls";
        timeStamp = dt.ToString("h:mm:ss");

        Debug.Log ("Application started on " + timeStamp);

        ending = "Unacquired";

        string path = Application.dataPath + "/Output/";

        if (!Directory.Exists(path))
        {
            Debug.Log("Create Directory");
            Directory.CreateDirectory(path);
        }

        Debug.Log("streaming assets: " + Application.streamingAssetsPath);
            

        if (System.IO.File.Exists (path + excelName)) {
			Debug.Log ("File Exist: ["+path+"]");

		} else {
			Debug.Log ("File DOES NOT Exist");

			//*****
			IWorkbook book = new HSSFWorkbook();;
            //using (var file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite)) {
            //	book = new XSSFWorkbook();
            //}
            ISheet sheet = book.CreateSheet("Batch"+ dt.ToString("yyyy-MM-dd"));
            sheet.CreateRow(0).CreateCell(0).SetCellValue("StartTime");

            //*
            sheet.GetRow(0).CreateCell(1).SetCellValue("EndTime");
            sheet.GetRow(0).CreateCell(2).SetCellValue("Attempt");
            sheet.GetRow(0).CreateCell(3).SetCellValue("Endings");
            //******/

            sheet.CreateRow(sheet.LastRowNum+1).CreateCell(0).SetCellValue("-END-");
            Debug.Log("Last ROW: " + sheet.LastRowNum);

            //save
            FileStream xfile = File.Create(path+excelName);
            book.Write(xfile);
            xfile.Close();
            

        }
	}   

    void Update()
    {
        // Win Condition
        Fire = GameObject.FindGameObjectsWithTag("Enemy"); // Checks if there are still fire in the building
        Debug.Log(Fire.Length/2 + "Fire Remaining");
        if (Fire.Length == 0)
        {
            StartCoroutine(FireWin());
        }
        
        // Lose Condition
        if (healthbar.value <= 0)
        {
            StartCoroutine(LostSmoke());
        }

        excelName = dt.ToString("yyyy-MM-dd") + ".xls";
        timeStamp = dt.ToString("h:mm:ss");

        string path = Application.dataPath + "/Output/";

        if (System.IO.File.Exists (path + excelName)) {
            //*****
            HSSFWorkbook book;
            using (FileStream file = new FileStream(@path+excelName, FileMode.Open, FileAccess.Read))
            {
                book = new HSSFWorkbook(file);
                file.Close();
            }

            ISheet sheet = book.GetSheetAt(0);

            IRow hRow = sheet.GetRow(0);
            IRow row = sheet.CreateRow(sheet.LastRowNum);

        }
    }

    void SaveEntry()
    {
        excelName = dt.ToString("yyyy-MM-dd") + ".xls";
        timeStamp = dt.ToString("h:mm:ss");

        string path = Application.dataPath + "/Output/";

            //*****
            HSSFWorkbook book;
            using (FileStream file = new FileStream(@path+excelName, FileMode.Open, FileAccess.Read))
            {
                book = new HSSFWorkbook(file);
                file.Close();
            }

            ISheet sheet = book.GetSheetAt(0);

            IRow row = sheet.CreateRow(sheet.LastRowNum);
            row.CreateCell(0).SetCellValue(timeStamp);

            dt = DateTime.Now;
            timeStamp = dt.ToString("h:mm:ss");
            row.CreateCell(1).SetCellValue(timeStamp);
            row.CreateCell(3).SetCellValue(ending);
            sheet.CreateRow(sheet.LastRowNum + 1).CreateCell(0).SetCellValue("-END-");
            Debug.Log("Application ended at " + timeStamp);

            using (FileStream file = new FileStream(@path+excelName, FileMode.Open, FileAccess.Write))
            {
                book.Write(file);
                file.Close();
            }
    }

    void OnApplicationQuit()
    {
        SaveEntry();
    } 
}
