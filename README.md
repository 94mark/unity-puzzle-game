# unity-puzzle-game
2048 퍼즐게임 제작

https://user-images.githubusercontent.com/90877724/165516747-80cb33f4-bfba-4aae-a9f3-33a86651be40.mp4

![20220427_210605](https://user-images.githubusercontent.com/90877724/165516782-5e2ba448-6610-453e-beea-8122b4c6451d.png)


## 1. 프로젝트 개요
### 1.1 개발 인원/기간 및 포지션
- 1인, 총 5일 소요
### 1.2 개발 환경
- Unity 2020.3.16f
- 언어 : C#
- OS : Window 10

## 2. 핵심 구현 내용
### 2-1. 이동 및 결합 로직
<img width="190" alt="20220511_181223" src="https://user-images.githubusercontent.com/90877724/167815320-f230fcae-e322-432e-8f25-022746f03ad3.png">
<img width="250" alt="20220511_182039" src="https://user-images.githubusercontent.com/90877724/167815910-60a5eba8-9eae-4b06-9a61-695fe0cf4960.png">
- 이동(Move) : 이동 될 좌표가 비어있고 이동 전 좌표가 존재하면 이동 될 좌표로 이동

- 왼쪽 방향 이동 시

```c#
for(y = 0; y <= 3; y++)
{
  for(x = 3; x >= 1; x--)
  {
    for(i = 0; i <= x-1; i++
    {      
      Square[i+1, y] //이동 전 좌표
      Square[i, y] // 이동 될 좌표
    }
  }
}
```

- 오른쪽 방향 이동 시
```c#
for(y = 0; y <= 3; y++)
{
  for(x = 0; x <= 2; x++)
  {
    for(i = 3; i >= x+1; i--
    {      
      Square[i-1, y] //이동 전 좌표
      Square[i, y] // 이동 될 좌표
    }
  }
}
```

- 위쪽 방향 이동 시
```c#
for(x = 0; x <= 3; x++)
{
  for(y = 0; y <= 2; y++)
  {
    for(i = 3; i >= y+1; i--
    {      
      Square[x, i-1] //이동 전 좌표
      Square[x, i] // 이동 될 좌표
    }
  }
}
```

- 아래쪽 방향 이동 시
```c#
for(x = 0; x <= 3; x++)
{
  for(y = 3; y >= 1; y--)
  {
    for(i = 0; i <= y-1; i++
    {      
      Square[x, i+1] //이동 전 좌표
      Square[x, i] // 이동 될 좌표
    }
  }
}
```

- 결합(Combine) : 이동 전 좌표와 이동 될 좌표가 비어있지 않고, 두개가 같고 둘다 combine 태그가 없다면 이동 전 좌표에서 이동 될 좌표로 이동 후 파괴, 이동 될 좌표는 2배, combine 태그 설정

<img width="189" alt="20220511_182247" src="https://user-images.githubusercontent.com/90877724/167816335-724118e0-7f03-4ddb-8fcb-0c52f4983585.png">


### 2-2. 애니메이션 세팅
- Spawn, Combine, Plus, Quit 애니메이션 구현, Trigger 방식으로 작동
-  블록 생성 및 결합, 점수 증가, 게임종료 창 생성 시 애니메이션 실행

### 2-3 [입력 값 설정](https://github.com/94mark/unity-puzzle-game/blob/5c56006aa02f0e5394cae6ad2cb5760df676cc44/puzzle2048/Assets/Scripts/GameManager.cs#L33)
- 마우스/손가락 drag 방향 설정 로직, Touch.Moved 이동 포지션의 좌표에서 Touch.Began 최초 터치 포지션의 차를 방향 벡터화(gap)
```c#
gap = (Input.GetMouseButton(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position) - firstPos;
gap.Normalize();
```
- 위/아래/오른쪽/왼쪽을 4분할 후 드래그 시 x, y 좌표의 방향에 따른 범위 설정, 방향에 맞는 이동 로직 반복문 추가
```c#
// 위
if (gap.y > 0 && gap.x > -0.5f && gap.x < 0.5f) for (x = 0; x <= 3; x++) for (y = 0; y <= 2; y++) for (i = 3; i >= y + 1; i--) MoveOrCombine(x, i - 1, x, i);
// 아래
else if (gap.y < 0 && gap.x > -0.5f && gap.x < 0.5f) for (x = 0; x <= 3; x++) for (y = 3; y >= 1; y--) for (i = 0; i <= y - 1; i++) MoveOrCombine(x, i + 1, x, i);
// 오른쪽
else if (gap.x > 0 && gap.y > -0.5f && gap.y < 0.5f) for (y = 0; y <= 3; y++) for (x = 0; x <= 2; x++) for (i = 3; i >= x + 1; i--) MoveOrCombine(i - 1, y, i, y);
// 왼쪽
else if (gap.x < 0 && gap.y > -0.5f && gap.y < 0.5f) for (y = 0; y <= 3; y++) for (x = 3; x >= 1; x--) for (i = 0; i <= x - 1; i++) MoveOrCombine(i + 1, y, i, y);
else return;
```
- [이동 및 결합 함수 구현](https://github.com/94mark/unity-puzzle-game/blob/5c56006aa02f0e5394cae6ad2cb5760df676cc44/puzzle2048/Assets/Scripts/GameManager.cs#L96)
```c#
void MoveOrCombine(int x1, int y1, int x2, int y2)
    {
        // 이동 될 좌표에 비어있고, 이동 전 좌표에 존재하면 이동
        if (Square[x2, y2] == null && Square[x1, y1] != null)
        {
            move = true;
            Square[x1, y1].GetComponent<Moving>().Move(x2, y2, false);
            Square[x2, y2] = Square[x1, y1];
            Square[x1, y1] = null;
        }

        // 둘다 같은 수일때 결합
        if (Square[x1, y1] != null && Square[x2, y2] != null && Square[x1, y1].name == Square[x2, y2].name && Square[x1, y1].tag != "Combine" && Square[x2, y2].tag != "Combine")
        {
            move = true;
            for (j = 0; j <= 16; j++) if (Square[x2, y2].name == n[j].name + "(Clone)") break;
            Square[x1, y1].GetComponent<Moving>().Move(x2, y2, true);
            Destroy(Square[x2, y2]);
            Square[x1, y1] = null;
            Square[x2, y2] = Instantiate(n[j + 1], new Vector3(1.2f * x2 - 1.8f, 1.2f * y2 - 1.8f, 0), Quaternion.identity);
            Square[x2, y2].tag = "Combine";
            Square[x2, y2].GetComponent<Animator>().SetTrigger("Combine");
            score += (int)Mathf.Pow(2, j + 2);
        }
```
### 2-4. [점수 및 게임 종료](https://github.com/94mark/unity-puzzle-game/blob/5c56006aa02f0e5394cae6ad2cb5760df676cc44/puzzle2048/Assets/Scripts/GameManager.cs#L66)


```c#
```

``
