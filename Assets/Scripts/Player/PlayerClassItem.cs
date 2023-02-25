using UnityEngine;

public class PlayerClassItem : Items
{
    public bool isUsed;
    public string className;
    public string sexe;

    public override void UseItem()
    {
        AudioManager.instance.PlayClipAt(soundEffect, transform.position);
        PlayerClass.instance.classes[PlayerClass.instance.currentClass].ChangeSexeClass(sexe);
        if (PlayerClass.instance.classes[PlayerClass.instance.currentClass].className != className)
        {
            PlayerClass.instance.ChangeCurrentClass(className);
        }
        isUsed = true;
        PlayerCustomManager.instance.ChangeCurrentClassUsed();
        PlayerCustomManager.instance.UpdateClassItem();
    }
}
