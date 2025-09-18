using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject2.Movements
{
    public class Flip : MonoBehaviour
    {
        public void FlipCharacter(float horizontal)
        {
            if (horizontal != 0) // horizontal 0'a esit degilsa alttaki saga ya da sola dondurme islemini yap demis olduk. yani 0'a esit ise yani herhangi bir tusa basilmiyor ise klavyede dondurme islemini yapma diyerek en son oldugu yone bakmasini saglamis olduk.
            {
                float mathfValue = Mathf.Sign(horizontal);
                if (transform.localScale.x == mathfValue) return;

                transform.localScale = new Vector2(mathfValue, 1f);  //alttaki if dongusuyle ayni isi yapiyor

                //if (Mathf.Sign(horizontal) > 0)
                //{
                //    _spriteRenderer.flipX = false;
                //}
                //else
                //{
                //    _spriteRenderer.flipX = true;
                //}

                //_spriteRenderer.flipX = Mathf.Sign(horizontal) > 0 ? false : true;  //turnary if dedigimiz yapi daha da kisa yazmamizi sagliyor yukaridaki iki senaryoyu yani en azindan if dongusune kiyasla
            }
        }
    }
}