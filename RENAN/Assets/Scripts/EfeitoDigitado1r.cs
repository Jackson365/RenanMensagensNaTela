using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EfeitoDigitador1 : MonoBehaviour
{
    private TextMeshProUGUI compTexto;
    private string mensagemOriginal;
    public float tempoPadrao = 0.04f;
    public float pausaBreve = 0.09f;
    public float pausaLonga = 0.2f;
    public bool imprimindo;

    private AudioSource som;

    private void Awake()
    {
        TryGetComponent(out compTexto);
        TryGetComponent(out som);
        mensagemOriginal = compTexto.text;
        compTexto.text = " ";
    }

    public void ImprimirMensagem(string mensagem)
    {
        if (imprimindo) return;
        imprimindo = true;
        StartCoroutine(LetraPorLetra(mensagem));
    }

    IEnumerator LetraPorLetra(string mensagem)
    {
        string msg = "";
        foreach( var letra in mensagem)
        {
            msg += letra;
            compTexto.text = msg;
            if(!som.isPlaying)
            {
                som.Play();
            }
            
            if(letra == ',')
            {
                yield return new WaitForSeconds(pausaBreve);
            }

            else if(letra is '.' or '?' or '!')
            {
                yield return new WaitForSeconds(pausaLonga);
            }

            else
            {
                yield return new WaitForSeconds(tempoPadrao);
            }
        }

        imprimindo = false;
        StopCoroutine(LetraPorLetra(mensagem));
    }

    public void Limpar()
    {
        compTexto.text = "";
    }
}
