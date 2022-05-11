# unity-puzzle-game
2048 퍼즐게임 제작

https://user-images.githubusercontent.com/90877724/165516747-80cb33f4-bfba-4aae-a9f3-33a86651be40.mp4

![20220427_210605](https://user-images.githubusercontent.com/90877724/165516782-5e2ba448-6610-453e-beea-8122b4c6451d.png)


## 1. 프로젝트 개요
### 1.1 개발 인원/기간 및 포지션
- 1인, 총 3일 소요
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

<img width="89" alt="20220511_182247" src="https://user-images.githubusercontent.com/90877724/167816335-724118e0-7f03-4ddb-8fcb-0c52f4983585.png">


### 3. 문제 해결 내용
### 3-1. 


```c#
```

``
