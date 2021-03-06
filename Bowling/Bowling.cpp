// Bowling.cpp: 콘솔 응용 프로그램의 진입점을 정의합니다.
//

#include "stdafx.h"


int main()
{
	int sum_score{};
	int score{};
	FRAME frame[10];


	cout << "볼링 점수 계산 프로그램" << endl;

	for (int i = 0; i < 10 ; ++i)
	{
		cout << "> " << i + 1 << " FRAME" << " - " << "1번째 투구를 하세요 : ";
		cin >> frame[i].first_bowling;

		frame[i].score = frame[i].first_bowling;

		if (frame[i].score == 10 )
		{
			frame[i].state = STRIKE;
			frame[i].second_bowling = NULL;
		}

		else
		{
			cout << "> " << i + 1 << " FRAME" << " - " << "2번째 투구를 하세요 : ";
			cin >> frame[i].second_bowling;
			frame[i].score += frame[i].second_bowling;

			if (frame[i].score == 10)
				frame[i].state = SPARE;
			else
			{
				frame[i].state = MISS;
				frame[i].bonus = true;
			}
		}
		// 10번 째 프레임이 스트라이크나 SPARE 일 때 
		if (i == 10 - 1 && (frame[i].state == STRIKE || frame[i].state == SPARE))
		{
			if (frame[i].state == STRIKE)
			{
				cout << "> " << i + 1 << " FRAME" << " - " << "2번째 투구를 하세요 : ";
				cin >> frame[i].second_bowling;
				frame[i].score += frame[i].second_bowling;
			}
			cout << "> " << i + 1 << " FRAME" << " - " << "보너스 투구를 하세요 : ";
			cin >> frame[i].bonus_bowling;
			frame[i].score += frame[i].bonus_bowling;
			frame[i].bonus = true;
		}

		sum_score = 0;

		for (int j = 0; j < i + 1; ++j)
		{
			// 보너스 점수 계산
			// j 다음 프레임 점수가 있어야 하고 보너스 점수 계산이 덜 됐을 때만 계산
			if (j + 1 < i + 1 && frame[j].bonus != true)
			{
				// 스페어 일때 다음 프레임 첫번째 투구만 더해주면 됨
				if (frame[j].state == SPARE)
				{
					frame[j].score += frame[j + 1].first_bowling;
					frame[j].bonus = true;
				}
				// 스트라이크 일 때 
				if (frame[j].state == STRIKE)		
				{
					// 다음 프레임이 스트라이크가 아닐 때 첫번째 , 두번째 투구 더해줌
					if (frame[j+1].state != STRIKE)
					{
						frame[j].score += frame[j + 1].first_bowling + frame[j+1].second_bowling;
						frame[j].bonus = true;
					}
					// 다음 프레임이 스트라이크 일 때 첫번째 투구 + 다다음 프레임 첫번째 투구
					else
					{
						if (j + 2 < i + 1)
						{
							frame[j].score += frame[j + 1].first_bowling + frame[j + 2].first_bowling;
							frame[j].bonus = true;
						}
						// 9 번째 일때
						if (j == 9 - 1)
						{
							frame[j].score += frame[j + 1].first_bowling + frame[j + 1].second_bowling;
							frame[j].bonus = true;
						}
					}
					
				}
			}

			// 총점수계산 계산 출력
			switch (frame[j].state)
			{
			case MISS:
				cout << frame[j].first_bowling << "," << frame[j].second_bowling;
				break;
			case SPARE:
				cout << frame[j].first_bowling << "," << "/" ;
				break;
			case STRIKE:
				cout << " X" ;
				break;
			}
			if (frame[j].bonus == true)
				cout << ":" << frame[j].score << " | ";
			else
				cout << ":" << " - " << " | ";
			sum_score += frame[j].score;
		}
		cout << "총 점수 :" << sum_score << endl;
		cout << "----------------------------------------------------------------------------------------------------" << endl;
	}
	
    return 0;
}

