using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "novoDialogo", menuName = "Scriptabla/Dialogo",order = 0)]

public class Dialogo : ScriptableObject
{
    public PerfilPersonagem personagem;
    public List<string> lista;
}
