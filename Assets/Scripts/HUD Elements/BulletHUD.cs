﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletHUD : MonoBehaviour {

    public Sprite[] HUDImages;
    Image imageComponent;

    void Start ()
    {
        imageComponent = GetComponent<Image>();
		ChangeHUD (0);
	}

    public void ChangeHUD(int bullets)
    {
        imageComponent.sprite = HUDImages[bullets];
    }
}
