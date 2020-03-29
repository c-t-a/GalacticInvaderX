/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public string damange = "100";

    public void SetHealthBarData(Transform targetTransform, RectTransform healthBarPanel)
    {
        this.targetCanvas = healthBarPanel;
        healthBar = GetComponent<RectTransform>();
        panel.RectTransform.sizeDelta = new Vector2(4, 95);



    }

    public void RepositionHealthBar()
    {
        
    }



    *//*#region PRIVATE_VARIABLES
    private Vector2 positionCorrection = new Vector2(0, 100);
    #endregion
    #region PUBLIC_REFERENCES
    public RectTransform targetCanvas;
    public RectTransform healthBar;
    public Transform objectToFollow;
    #endregion
    #region PUBLIC_METHODS
    public void SetHealthBarData(Transform targetTransform, RectTransform healthBarPanel)
    {
        this.targetCanvas = healthBarPanel;
        healthBar = GetComponent<RectTransform>();
        objectToFollow = targetTransform;
        RepositionHealthBar();
        healthBar.gameObject.SetActive(true);
    }
    public void OnHealthChanged(float healthFill)
    {
        healthBar.GetComponent<Image>().fillAmount = healthFill;
    }
    #endregion
    #region UNITY_CALLBACKS
    void Update()
    {
        *//*RepositionHealthBar();*//*
    }
    #endregion
    #region PRIVATE_METHODS
    public void RepositionHealthBar()
    {
        FloatingTextController.CreateFloatingText(damange, transform);
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(objectToFollow.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * targetCanvas.sizeDelta.x) - (targetCanvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * targetCanvas.sizeDelta.y) - (targetCanvas.sizeDelta.y * 0.5f)));
        //now you can set the position of the ui element
        healthBar.anchoredPosition = WorldObject_ScreenPosition;
    }
    #endregion*//*
}






*//*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action<Health> OnHealthAdded = delegate { };
    public static event Action<Health> OnHealthRemoved = delegate { };

    [SerializeField]
    private int maxHealth = 100;

    public int CurrentHealth { get; private set; }

    public event Action<float> OnHealthPctChanged = delegate { };

    public void OnEnable()
    {
        CurrentHealth = maxHealth;
        OnHealthAdded(this);
    }

    public void ModifyHealth(int amount)
    {
        CurrentHealth += amount;

        float currentHealthPct = (float)CurrentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    private void Update()
    {
*//*        //original code (reduce HP when space is pressed)
        if (Input.GetKeyDown(KeyCode.Space))
            ModifyHealth(-20);*//*
    }

    private void OnDisable()
    {
        OnHealthRemoved(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/
