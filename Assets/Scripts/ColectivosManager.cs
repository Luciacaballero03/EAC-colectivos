using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectivosManager : MonoBehaviour
{

    [SerializeField] ColectivoScript[] colectivos;
    [SerializeField] float maxCapacidad = 60;
    [SerializeField] float minCapacidad = 30;

    
    // Start is called before the first frame update
    void Start()
    {
        colectivos = FindObjectsOfType<ColectivoScript>();
        DesactivarTodosLosColectivos();

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivarTodosLosColectivos();
            AsignarCapacidadRandomALosColectivos();
            CargarCombustibleRandomATodosLosColectivos();
            ActivarColectivosConMenosDeMedioTanque();
            ActivarSignoDeAdvertenciaEnColectivosConMenosDe10DeCombustible();
            MostrarPromedioDeCombustible();
            MostrarCombustibleFaltanteParaLlenarTodosLosTanques();
        }
    }

    private void ActivarTodosLosColectivos()
    {
        for (int i=0; i<colectivos.Length; i++){
        colectivos[i].gameObject.SetActive(true);
        }
    }

    private void DesactivarTodosLosColectivos()
    {
        for (int i=0; i<colectivos.Length; i++){
        colectivos[i].gameObject.SetActive(false);
        }
    }

    private void AsignarCapacidadRandomALosColectivos()
    {
        for (int i=0; i < colectivos.Length; i++){
            colectivos[i].capacidadTanque = UnityEngine.Random.Range(minCapacidad, maxCapacidad);
        }
        
        //respetar los valores max y min establecidos en este script
    }

    private void CargarCombustibleRandomATodosLosColectivos()
    {
        for (int i = 0; i< colectivos.Length; i++){
            colectivos[i].cargaActual = UnityEngine.Random.Range(0,colectivos[i].capacidadTanque);
        }
        //cargar una cantidad aleatoria de combustible a cada colectivo
        //respetando la capacidad máxima del tanque
    }
    private void ActivarColectivosConMenosDeMedioTanque()
    {
        for (int i=0; i < colectivos.Length; i++){
            if (colectivos[i].capacidadTanque < (colectivos[i].capacidadTanque*0.5f)){
                colectivos[i].gameObject.SetActive(true);
            }
            else{
                colectivos[i].gameObject.SetActive(false);
            }
        }
    }
    private void ActivarSignoDeAdvertenciaEnColectivosConMenosDe10DeCombustible()
    {
        for (int i = 0; i<colectivos.Length; i++){
            if (colectivos[i].cargaActual < 10f)
            {
                colectivos[i].WarningSign.SetActive(true);
            }
        }
    }

    private void MostrarPromedioDeCombustible()
    {
        //mostrar en consola el promedio de combustible de todos los colectivos
    }

    private void MostrarCombustibleFaltanteParaLlenarTodosLosTanques()
    {
        //mostrar en consola la cantidad de combustible necesaria para llenar todos los tanques
        //de todos los colectivos
    }
}
