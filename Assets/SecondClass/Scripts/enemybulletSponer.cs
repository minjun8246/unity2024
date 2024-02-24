using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybulletSponer : MonoBehaviour
{
    // �Ѿ��� �����ϴ� ����. �̸� ����� ��ǰ�� �ݺ��ؼ� �����ϴ� Ŭ����.

    public GameObject bullet;
    public Transform bulletTransform;
    public float spawnTime = 3f;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    // �ڷ�ƾ�� ����ؼ� �Ѿ��� �����غ��̴ϴ�.


    IEnumerator SpawnBullet()
    {
        while (true)
        {
            GameObject enemybullet =
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
    }

    // �Ѿ��� ������ �����ϰ� ���� ������ ���� �� ����..
    // �Ǵ� Enemy�� �׾ ������ �� ���� ����ؼ� ���� �߻��մϴ�.
}

