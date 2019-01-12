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
		if (frame[i].score == 10)
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
				frame[i].state = MISS;
		}


		if (i > 0 && frame[i].state != STRIKE)
		{
			if (frame[i - 1].state == SPARE)
				frame[i - 1].score += frame[i].first_bowling;
			else if (frame[i - 1].state == STRIKE)
				frame[i - 1].score += frame[i].score;
		}
		
		sum_score = 0;
		for (int j = 0; j < i + 1; ++j)
		{
			cout << frame[j].first_bowling << "," << frame[j].second_bowling << " | ";
			sum_score += frame[j].score;
		}
		cout << "총 점수 :" << sum_score << endl;
	}
	
    return 0;
}

