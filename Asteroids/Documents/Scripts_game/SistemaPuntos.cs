using UnityEngine;
using TMPro;

public class SistemaPuntos : MonoBehaviour
{
    private static TextMeshProUGUI textoUI;
    private static int puntaje = 0;
    private static bool YaGano = false;

    private void Awake()
    {
        textoUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ActualizarTexto();
    }

    public static void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
        ActualizarTexto();
        if (puntaje >= 500 && !YaGano)
        {
            YaGano = true;
            Debug.Log("Ganaste");
        }
    }

    private static void ActualizarTexto()
    {
        if (textoUI != null)
        {
            textoUI.text = "PUNTOS: " + puntaje;
        }
    }
    public static void ReiniciarPuntos()
    {
        puntaje = 0;       
        YaGano = false;  
        ActualizarTexto(); 
    }
}
