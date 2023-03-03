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
        PlayerClass.instance.ChangeCurrentClass(className);
        PlayerClass.instance.classes[PlayerClass.instance.currentClass].ChangeSexeClass(sexe);
        isUsed = true;
        PlayerCustomManager.instance.ChangeCurrentClassUsed();
        PlayerCustomManager.instance.UpdateClassItem();
    }
}
