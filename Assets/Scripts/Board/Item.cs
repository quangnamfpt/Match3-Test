﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utilities;

[Serializable]
public class Item
{
    public enum eItemType
    {
        NONE,
        NORMAL_TYPE_ONE,
        NORMAL_TYPE_TWO,
        NORMAL_TYPE_THREE,
        NORMAL_TYPE_FOUR,
        NORMAL_TYPE_FIVE,
        NORMAL_TYPE_SIX,
        NORMAL_TYPE_SEVEN,
        BONUS_HORIZONTAL,
        BONUS_VERTICAL,
        BONUS_ALL,
    }
    
    public eItemType ItemType;

    public virtual void SetType(eItemType type)
    {
        ItemType = type;
    }
    
    public Cell Cell { get; private set; }

    public Transform View { get; private set; }


    /*public virtual void SetView()
    {
        string prefabname = GetPrefabName();

        if (!string.IsNullOrEmpty(prefabname))
        {
            GameObject prefab = Resources.Load<GameObject>(prefabname);
            if (prefab)
            {
                View = GameObject.Instantiate(prefab).transform;
            }
        }
    }*/
    
    //New
    public virtual void SetView()
    {
        var prefabName = GetPrefabName();

        if (string.IsNullOrEmpty(prefabName)) return;
        //GameObject prefab = Resources.Load<GameObject>(prefabname);
        var prefab = PrefabCache.Load(prefabName);

        if (!prefab) return;
            
        //View = GameObject.Instantiate(prefab).transform;
        View = SimplePool.Spawn(prefab, Vector3.zero).transform;
        View.localScale = Vector3.one;
        
        var sr = View.GetComponent<SpriteRenderer>();
        sr.sprite = MainMenuController.Instance.Item_Data.GetSprite(ItemType);
    }

    protected virtual string GetPrefabName() { return string.Empty; }

    public virtual void SetCell(Cell cell)
    {
        Cell = cell;
    }

    internal void AnimationMoveToPosition()
    {
        if (View == null) return;

        View.DOMove(Cell.transform.position, 0.2f);
    }

    public void SetViewPosition(Vector3 pos)
    {
        if (View)
        {
            View.position = pos;
        }
    }

    public void SetViewRoot(Transform root)
    {
        if (View)
        {
            View.SetParent(root);
        }
    }

    public void SetSortingLayerHigher()
    {
        if (View == null) return;

        SpriteRenderer sp = View.GetComponent<SpriteRenderer>();
        if (sp)
        {
            sp.sortingOrder = 1;
        }
    }


    public void SetSortingLayerLower()
    {
        if (View == null) return;

        SpriteRenderer sp = View.GetComponent<SpriteRenderer>();
        if (sp)
        {
            sp.sortingOrder = 0;
        }

    }

    internal void ShowAppearAnimation()
    {
        if (View == null) return;

        Vector3 scale = View.localScale;
        View.localScale = Vector3.one * 0.1f;
        View.DOScale(scale, 0.1f);
    }

    internal virtual bool IsSameType(Item other)
    {
        return false;
    }

    internal virtual void ExplodeView()
    {
        StopAnimateForHint();
        if (View)
        {
            View.DOScale(0.1f, 0.1f).OnComplete(
                () =>
                {
                    //GameObject.Destroy(View.gameObject);
                    SimplePool.Despawn(View.gameObject);
                    View = null;
                }
                );
        }
    }



    internal void AnimateForHint()
    {
        StopAnimateForHint();
        if (View)
        {
            View.DOPunchScale(View.localScale * 0.1f, 0.1f).SetLoops(-1);
        }
    }

    internal void StopAnimateForHint()
    {
        if (View)
        {
            View.DOKill();
        }
    }

    internal void Clear()
    {
        Cell = null;

        if (View)
        {
            //GameObject.Destroy(View.gameObject);
            SimplePool.Despawn(View.gameObject);
            View = null;
        }
    }
    
    public virtual void Reset()
    {
        View = null;
    }
}
