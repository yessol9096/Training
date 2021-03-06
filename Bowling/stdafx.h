// stdafx.h : 자주 사용하지만 자주 변경되지는 않는
// 표준 시스템 포함 파일 또는 프로젝트 관련 포함 파일이
// 들어 있는 포함 파일입니다.
//

#pragma once

#include "targetver.h"

#include <stdio.h>
#include <tchar.h>
#include <iostream>

using namespace std;


typedef struct Frame
{
	int state;				// 스트라이크인지 스페어인지 미스인지
	int first_bowling;		// 첫번째 투구
	int second_bowling;		// 두번째 투구
	int bonus_bowling;		// 보너스 투구
	int score;				// 프레임 점수 
	bool bonus;				// 보너스 점수 합산 여부
}FRAME;


#define MISS	0		
#define SPARE	1
#define	STRIKE	2	


// TODO: 프로그램에 필요한 추가 헤더는 여기에서 참조합니다.
