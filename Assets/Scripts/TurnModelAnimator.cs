using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnModelAnimator : MonoBehaviour
{
    private Animator animator;
    private bool isTurningLeft = false;
    private bool isTurningRight = false;

    private float time = 0.5f; // Czas trwania obrotu (0.5 sekundy)
    public float rotateDegreeFROM = 30;
    public float rotateDegreeTO = 90;
    public float rotateDegree = 0;
    private float rotateAngels = 0;
    public string LeftStateName = "";
    public string RightStateName = "";

    void Start()
    {
        // Pobieramy komponent Animator
        animator = GetComponent<Animator>();

        RandomDegree();
        // covert normal Degee to Angels -> roatet per time
        rotateAngels = rotateDegree / (time*10);
    }

    private void RandomDegree(){
        rotateDegree = Random.Range(rotateDegreeFROM, rotateDegreeTO);
    }

    void Update()
    {
        // Jeśli animator jest w stanie 'Turn Left' i nie wykonujemy jeszcze obrotu
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(LeftStateName) && !isTurningLeft)
        {
            isTurningLeft = true;
            StartCoroutine(TurnObject(-1));
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName(RightStateName) && !isTurningRight)
        {
            isTurningRight = true;
            StartCoroutine(TurnObject(1));
        }

    }

    // Funkcja do wykonania obrotu
    private System.Collections.IEnumerator TurnObject(int direction)
    {
        if (direction==-1 && rotateAngels>0){
            rotateAngels = -rotateAngels;
        }
        else if (direction==1 && rotateAngels<0){
            rotateAngels = -rotateAngels;
        }

        Quaternion startRotation = transform.rotation;
        
        // Nowa rotacja na podstawie aktualnego kąta obiektu
        // za każda iteracje obiekt przeuswa sie o tyle     wzór: angels = rotationDegree/time
        Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + rotateAngels, 0);


        // Animacja obrotu
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t / time);
            yield return null;
        }

        transform.rotation = targetRotation; // Ustawiamy końcową rotację

        // Po zakończeniu obrotu ustawiamy, że obrót został zakończony
        isTurningLeft = false;
        isTurningRight = false;
    }


}
