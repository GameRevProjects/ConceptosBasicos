using System;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    private void Awake()
    {
        //Prueba 1
        Guardar();
        Cargar();
        Eliminar();
        Cargar();
    }

    public void Guardar()
    {
        PlayerPrefs.SetInt("nivel", 100);
        PlayerPrefs.SetFloat("experiencia", 10.5f);
        PlayerPrefs.SetString("nombre", "FricoDev");
    }

    public void Cargar()
    {
        int nivel = PlayerPrefs.GetInt("nivel", 1); //retorna 1 como default
        float experiencia = PlayerPrefs.GetFloat("experiencia");
        string nombre = PlayerPrefs.GetString("nombre");

        int oro = PlayerPrefs.GetInt("oro"); //retorna 0
        string apodo = PlayerPrefs.GetString("apodo"); //retorna ""
        
        Debug.Log("Nivel: " + nivel);
        Debug.Log("Experiencia: " + experiencia);
        Debug.Log("Nombre: " + nombre);
        Debug.Log("Oro: " + oro);
        Debug.Log("Apodo: " + apodo);
    }

    public void Eliminar()
    {
        PlayerPrefs.DeleteKey("nivel");
        PlayerPrefs.DeleteAll();
    }
}