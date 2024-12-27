using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Security.Cryptography;  

public class AESHandler : MonoBehaviour
{ 
    public static AESHandler instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }

  
  //AES - Encription 
  public static string AESEncryption(string inputData)
    {
        string hakunamatata = "BOGDAN0105199ANTONIO27041994LAMB"; //set any string of 32 chars
        string timonpumbaa = "0105199427041994"; //set any string of 16 chars
        AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
        AEScryptoProvider.BlockSize = 128;
        AEScryptoProvider.KeySize = 256;
        AEScryptoProvider.Key = ASCIIEncoding.ASCII.GetBytes(hakunamatata);
        AEScryptoProvider.IV = ASCIIEncoding.ASCII.GetBytes(timonpumbaa);
        AEScryptoProvider.Mode = CipherMode.CBC;
        AEScryptoProvider.Padding = PaddingMode.PKCS7;
 
        byte[] txtByteData = ASCIIEncoding.ASCII.GetBytes(inputData);
        ICryptoTransform trnsfrm = AEScryptoProvider.CreateEncryptor(AEScryptoProvider.Key, AEScryptoProvider.IV);
 
        byte[] result = trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
        return Convert.ToBase64String(result);
        
    }
 
    //AES -  Decryption
    public static string AESDecryption(string inputData)
    {
        string hakunamatata = "BOGDAN0105199ANTONIO27041994LAMB"; //set any string of 32 chars
        string timonpumbaa = "0105199427041994"; //set any string of 16 chars
        AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
        AEScryptoProvider.BlockSize = 128;
        AEScryptoProvider.KeySize = 256;
        AEScryptoProvider.Key = ASCIIEncoding.ASCII.GetBytes(hakunamatata);
        AEScryptoProvider.IV = ASCIIEncoding.ASCII.GetBytes(timonpumbaa);
        AEScryptoProvider.Mode = CipherMode.CBC;
        AEScryptoProvider.Padding = PaddingMode.PKCS7;
 
        byte[] txtByteData = Convert.FromBase64String(inputData);
        ICryptoTransform trnsfrm = AEScryptoProvider.CreateDecryptor();
 
        byte[] result = trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
        return ASCIIEncoding.ASCII.GetString(result);
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
