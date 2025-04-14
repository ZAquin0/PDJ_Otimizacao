using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private enum TipoDeMovimentacao {Simple, Circular, Random};
    [SerializeField] private TipoDeMovimentacao pathType;
    [SerializeField] private Vector3[] destinies;
    [SerializeField] private float speed;
    [SerializeField] [Range(-1, 1)] private int direction = 1;
    private int index = 0;
    private void FixedUpdate()
    {
        Vector3 dir = destinies[index] - transform.position;
        if(dir.magnitude <= 0.1f)
        {
            if(pathType == TipoDeMovimentacao.Circular)
                index = (index + 1) % destinies.Length;
            else if(pathType == TipoDeMovimentacao.Random)
            {
                int random = Random.Range(0, destinies.Length - 1);
                if(random >= index) random++;
                index = random;                
            }
            else
            {
                index += direction;
                if(index == 0) direction = 1;
                else if(index == destinies.Length - 1) direction = -1; 
            }              
        }
        transform.position += dir.normalized * speed * Time.fixedDeltaTime;
    }
    public void CaminhadaSimples() => pathType = TipoDeMovimentacao.Simple;
    public void CaminhadaCircular() => pathType = TipoDeMovimentacao.Circular;
    public void CaminhadaAleatoria() => pathType = TipoDeMovimentacao.Random;
}
