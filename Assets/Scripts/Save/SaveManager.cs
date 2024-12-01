using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // P.S.: Mesmo criptografando aqui, sem salvar em um backend, basta algu�m tem acesso ao c�digo que
    // facilmente poder� descriptografar a string.

    // Caminho do arquivo de save
    private string savePath = Application.streamingAssetsPath + "/Save/";

    private string key1 = "abcdefghijklmnopqrstuvwxyz0123456789{':L>?<*&^%$#@!~})( -=_+|";
    private string key2 = "h0fnxliu3soc9vbjw8g76e5mtdy4r2pkqza1*&^%$#@!~}{':L>?<()-=_+ |";

    // String a ser salva
    [InfoBox("Os textos s�o salvos criptografados e s�o convertidos para min�sculo")]
    [SerializeField] private string stringToSave;
    // String carregada (SerializeField pra ser vis�vel no inspetor, mas deveria n�o ter)
    // tamb�m daria para ler usando o modo debug do inspetor, mas deixei assim por praticidade
    [SerializeField] private string stringLoaded; 

    // M�todo que cria a pasta
    private void CreateFolder()
    {
        // Verifica se a pasta n�o existe
        if (!System.IO.Directory.Exists(savePath))
        {
            // Cria a pasta
            System.IO.Directory.CreateDirectory(savePath);
        }
    }

    // M�todo que cria o arquivo
    private void CreateFile()
    {
        // Cria a pasta
        CreateFolder();

        // Verifica se o arquivo n�o existe
        if (!System.IO.File.Exists(savePath + "save.txt"))
        {
            // Cria o arquivo
            System.IO.File.Create(savePath + "save.txt").Dispose();
        }
    }

    // M�todo que salva a string
    [Button ("Salvar Texto")]
    public void Save()
    {
        // Cria o arquivo
        CreateFile();

        // Salva a string no arquivo
        Debug.Log("Texto a Salvar: " + stringToSave);
        System.IO.File.WriteAllText(savePath + "save.txt", EncryptString(stringToSave));
        Debug.Log("Texto Salvo Encriptado: " + EncryptString(stringToSave));
    }

    // M�todo que carrega a string
    [Button("Carregar Texto")]
    public void Load()
    {
        // Cria o arquivo
        CreateFile();

        // Read the string from the file
        stringLoaded = System.IO.File.ReadAllText(savePath + "save.txt");
        Debug.Log("Texto Carregado Encriptado: " + stringLoaded);
        stringLoaded = DecryptString(stringLoaded);
        Debug.Log("Texto Carregado: " + stringLoaded);
    }

    // Criptografar string
    private string EncryptString(string input)
    {
        // Transforma a string em um array de caracteres
        char[] caracteres = input.ToLower().ToCharArray();

        // Percorre o array de caracteres
        for (int i = 0; i < caracteres.Length; i++)
        {
            // Verifica se o caractere est� contido na key1
            if (key1.Contains(caracteres[i]))
            {
                // Substitui o caractere pelo caractere correspondente na key2
                caracteres[i] = key2[key1.IndexOf(caracteres[i])];
            }
        }

        // Retorna a string criptografada
        return new string(caracteres);
    }

    // Descriptografar string
    private string DecryptString(string input)
    {
        // Transforma a string em um array de caracteres
        char[] caracteres = input.ToCharArray();
        // Percorre o array de caracteres
        for (int i = 0; i < caracteres.Length; i++)
        {
            // Verifica se o caractere est� contido na key2
            if (key2.Contains(caracteres[i]))
            {
                // Substitui o caractere pelo caractere correspondente na key1
                caracteres[i] = key1[key2.IndexOf(caracteres[i])];
            }
        }

        // Retorna a string descriptografada
        return new string(caracteres);
    }
}
