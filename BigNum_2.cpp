#include <iostream>
#include <ctime>
#include <random>
#include <algorithm>

#include <cstring>

using namespace std;

typedef unsigned char BASE;
typedef unsigned short DBASE;
#define BASE_SIZE (sizeof(BASE) * 8)
#define BASENUM ((DBASE)1 << BASE_SIZE)

mt19937 rnd(time(0));

class BN
{
private:
	BASE *coef;
	int len, maxlen;

	BN shift(int x)
	{
		int m = len,
			n = len + x;
		BN bn(n);
		bn.len = n;

		for (int i = 0; i < m; i++)
			bn.coef[n - 1 - i] = coef[m - 1 - i];

		while (bn.coef[bn.len - 1] == 0 && (bn.len > 1))
			bn.len--;

		return bn;
	}

public:
	BN(int m = 1, bool f = 0) : maxlen(m), len(1)
	{
		coef = new BASE[maxlen]{};
		if (!f)
			for (int i = 0; i < maxlen; coef[i] = 0, i++)
				;

		else
		{
			for (int i = 0; i < maxlen; coef[i] = rnd(), i++)
				;
			len = maxlen;
			while (coef[len - 1] == 0)
				coef[len - 1] = rnd();
		}
	}

	BN(const BN &bn) : len(bn.len), maxlen(bn.maxlen)
	{
		coef = new BASE[maxlen]{};
		for (int i = 0; i < len; coef[i] = bn.coef[i], i++)
			;
	}

	~BN() { delete[] coef; }

	BN &operator=(const BN &bn)
	{
		if (this != &bn)
		{
			if (coef)
				delete[] coef;
			len = bn.len;
			maxlen = bn.maxlen;
			coef = new BASE[maxlen]{};

			for (int i = 0; i < len; i++)
				coef[i] = bn.coef[i];
		}

		return *this;
	}

	void InputHEX(const char *s)
	{
		delete[] coef;
		len = (strlen(s) - 1) / (BASE_SIZE / 4) + 1;
		maxlen = len;
		coef = new BASE[maxlen]{};

		int i, j = 0, k = 0;
		char tmp;
		for (i = strlen(s) - 1; i >= 0; i--)
		{
			if (('0' <= s[i]) && (s[i] <= '9'))
				tmp = s[i] - '0';
			else if (('a' <= s[i]) && (s[i] <= 'f'))
				tmp = s[i] - 'a' + 10;
			else if (('A' <= s[i]) && (s[i] <= 'F'))
				tmp = s[i] - 'A' + 10;
			else
				exit(1);

			coef[j] |= tmp << (k * 4);
			k++;
			if (k >= BASE_SIZE / 4)
			{
				k = 0;
				j++;
			}
		}
		while (coef[len - 1] == 0 && (len > 1))
			len--;
	}

	void OutputHEX()
	{
		char *s = new char[BASE_SIZE / 4 * len + 1];

		int i, j = 0, k;
		char tmp;
		bool f = 1;
		for (i = len - 1; i >= 0; i--)
		{
			k = BASE_SIZE - 4;
			while (k >= 0)
			{
				tmp = (coef[i] >> k) & 0xf;
				if (tmp == 0 && f)
				{
					k -= 4;
					continue;
				}
				else if (tmp != 0 && f)
					f = 0;

				if ((0 <= tmp) && (tmp <= 9))
					s[j] = (char)(tmp + '0');
				else if ((10 <= tmp) && (tmp <= 15))
					s[j] = (char)(tmp - 10 + 'a');

				j++;
				k -= 4;
			}
		}
		if (j == 0)
			s[j++] = '0';
		s[j] = '\0';
		cout << s;
		delete[] s;
	}

	bool operator>(const BN &bn) const
	{
		if (len != bn.len)
			return len > bn.len;

		for (int i = len - 1; i >= 0; i--)
			if (coef[i] != bn.coef[i])
				return coef[i] > bn.coef[i];
		return 0;
	}

	bool operator<(const BN &bn) const
	{
		return (bn > *this);
	}

	bool operator>=(const BN &bn) const
	{
		return !(*this < bn);
	}

	bool operator<=(const BN &bn) const
	{
		return !(*this > bn);
	}

	bool operator==(const BN &bn) const
	{
		return (*this <= bn && *this >= bn);
	}

	bool operator!=(const BN &bn) const
	{
		return !(*this == bn);
	}

	BN operator+(const BN &bn)
	{
		DBASE tmp;
		int n = len,
			m = bn.len;
		int l = max(n, m) + 1,
			t = min(n, m),
			i = 0,
			k = 0;

		BN sum(l);
		sum.len = l;
		while (i < t)
		{
			tmp = (DBASE)coef[i] + (DBASE)bn.coef[i] + (DBASE)k;
			sum.coef[i] = (BASE)tmp;

			k = (BASE)(tmp >> BASE_SIZE);
			i++;
		}

		while (i < n)
		{
			tmp = (DBASE)coef[i] + (DBASE)k;
			sum.coef[i] = (BASE)tmp;

			k = (BASE)(tmp >> BASE_SIZE);
			i++;
		}

		while (i < m)
		{
			tmp = (DBASE)bn.coef[i] + (DBASE)k;
			sum.coef[i] = (BASE)tmp;

			k = (BASE)(tmp >> BASE_SIZE);
			i++;
		}

		sum.coef[i] = k;
		if (sum.coef[i] == 0)
			sum.len--;

		return sum;
	}

	BN &operator+=(const BN &bn)
	{
		*this = *this + bn;
		return *this;
	}

	void len_norm()
	{
		len = maxlen; // сначала len = maxlen
		// пока в кооффициенте - 0, мы уменьшаем len
		while (len > 0 && coef[len - 1] == 0)
		{
			len--;
		}
		// если дошли до конца, то оставляем длину числа - 1, т.е. получим 0
		if (len == 0)
		{
			len = 1;
		}
	}

	BN operator-(const BN &bn)
	{
		DBASE tmp;
		int n = len,
			m = bn.len;
		int i = 0,
			k = 0;
		BN sub(n);
		sub.len = n;

		if (bn > *this)
			exit(2);

		while (i < m)
		{
			tmp = ((DBASE)1 << BASE_SIZE) | coef[i];
			tmp = tmp - bn.coef[i] - k;
			sub.coef[i] = (BASE)tmp;

			k = !(tmp >> BASE_SIZE);
			i++;
		}

		while (i < n)
		{
			tmp = ((DBASE)1 << BASE_SIZE) | coef[i];
			tmp -= k;
			sub.coef[i] = (BASE)tmp;

			k = !(tmp >> BASE_SIZE);
			i++;
		}

		while (sub.coef[sub.len - 1] == 0 && (sub.len > 1))
			sub.len--;

		return sub;
	}

	BN &operator-=(const BN &bn)
	{
		*this = *this - bn;
		return *this;
	}

	BN operator*(const BASE &num)
	{
		DBASE tmp;
		int i = 0,
			n = len + 1;
		BASE k = 0;

		BN mul(n);
		mul.len = n;
		while (i < n - 1)
		{
			tmp = (DBASE)coef[i] * (DBASE)num + (DBASE)k;
			mul.coef[i] = (BASE)tmp;

			k = (BASE)(tmp >> BASE_SIZE);
			i++;
		}

		mul.coef[i] = k;
		while (mul.coef[mul.len - 1] == 0 && (mul.len > 1))
			mul.len--;

		return mul;
	}

	BN operator*(const BN &bn)
	{
		DBASE tmp;
		int n = len, m = bn.len;
		int l = n + m;

		BN mul(l);
		mul.len = l;
		int j = 0;
		while (j < m)
		{
			if (bn.coef[j] != 0)
			{
				int i = 0;
				BASE k = 0;
				while (i < n)
				{
					tmp = (DBASE)coef[i] * (DBASE)bn.coef[j] + (DBASE)mul.coef[i + j] + (DBASE)k;
					mul.coef[i + j] = (BASE)tmp;

					k = (BASE)(tmp >> BASE_SIZE);
					i++;
				}
				mul.coef[j + n] = (BASE)k;
			}
			j++;
		}

		while (mul.coef[mul.len - 1] == 0 && (mul.len > 1))
			mul.len--;

		return mul;
	}

	BN &operator*=(const BN &bn)
	{
		*this = *this * bn;
		return *this;
	}

	BN operator+(const BASE &num)
	{
		DBASE tmp;
		int n = len + 1, i = 0, k = 0;
		BN sum(n);
		sum.len = n;

		tmp = (DBASE)coef[i] + (DBASE)num;
		sum.coef[i] = (BASE)tmp;
		k = (BASE)(tmp >> BASE_SIZE);
		i++;

		while (i < n - 1)
		{
			tmp = (DBASE)coef[i] + (DBASE)k;
			sum.coef[i] = (BASE)tmp;

			k = (BASE)(tmp >> BASE_SIZE);
			i++;
		}

		sum.coef[i] = k;
		while (sum.coef[sum.len - 1] == 0 && (sum.len > 1))
			sum.len--;

		return sum;
	}

	BN operator/(const BASE &num)
	{
		if (num == 0)
			exit(3);

		DBASE tmp;
		int n = len,
			i = 0;

		BASE r = 0;
		BN div(n);
		div.len = n;

		while (i < n)
		{
			tmp = ((DBASE)r << BASE_SIZE) + (DBASE)coef[n - i - 1];
			div.coef[n - i - 1] = (BASE)(tmp / num);

			r = (BASE)(tmp % num);
			i++;
		}

		while (div.coef[div.len - 1] == 0 && (div.len > 1))
			div.len--;

		return div;
	}

	BN operator/(BN &x)
	{
		if (x.len == 1 && x.coef[0] == 0)
		{
			throw invalid_argument("devider eq 0");
		}

		if (*this < x)
		{
			cout << "v > u" << endl;
			BN result(1);
			return result;
		}

		if (x.len == 1)
		{
			return *this / x.coef[0];
		}

		int m = len - x.len; // длина результата
		DBASE b = ((DBASE)1 << BASE_SIZE);
		DBASE d = b / (DBASE)(x.coef[x.len - 1] + (BASE)1); // для нормализации, чтобы воспоьзоваться теоремой 2

		int j = m; // начальная установка - длина резальтата (столько раз делим) - 2
		int k = 0;

		// нормализация  - 1
		BN divisible = *this;
		divisible *= d;

		BN divider = x;
		divider *= d;

		// длина результата - это или m, или m + 1
		BN result(m + 1);
		result.len = m + 1;

		// разряд не увеличился 0
		if (divisible.len == len)
		{						/// сравниваем длину нормализованного с исходным
			divisible.maxlen++; // увеличваем len для ноля
			divisible.len = maxlen;
			delete[] divisible.coef; // удаляю всё
			divisible.coef = new BASE[maxlen];
			for (int i = 0; i < len; i++)
			{ // заново перезаписываю туда всё, что было
				divisible.coef[i] = coef[i];
			}
			divisible *= d; // снова нормализую
			divisible.len++;
			divisible.coef[divisible.len - 1] = 0; // ЯВНО записываю 0 в начало
		}

		// деление
		while (j >= 0)
		{
			// Вычесление q`
			// Теорама А q` >= q
			// по формулам считаем q` и r` (q` - результаты делений и r` - остатки)
			// этап 3
			DBASE q = (DBASE)((DBASE)((DBASE)((DBASE)(divisible.coef[j + divider.len]) * (DBASE)(b)) + (DBASE)(divisible.coef[j + divider.len - 1])) / (DBASE)(divider.coef[divider.len - 1]));
			DBASE r = (DBASE)((DBASE)((DBASE)((DBASE)(divisible.coef[j + divider.len]) * (DBASE)(b)) + (DBASE)(divisible.coef[j + divider.len - 1])) % (DBASE)(divider.coef[divider.len - 1]));

			// проверки на уменьшение q`
			if (q == b || (DBASE)((DBASE)(q) * (DBASE)(divider.coef[divider.len - 2])) > (DBASE)((DBASE)((DBASE)(b) * (DBASE)(r)) + (DBASE)(divisible.coef[j + divider.len - 2])))
			{
				q--;
				r = (DBASE)(r) + (DBASE)(divider.coef[divider.len - 1]);
				//проверяем остаток 
				if ((DBASE)(r) < b)
				{
					if (q == b || (DBASE)((DBASE)(q) * (DBASE)(divider.coef[divider.len - 2])) > (DBASE)((DBASE)((DBASE)(b) * (DBASE)(r)) + (DBASE)(divisible.coef[j + divider.len - 2])))
					{
						q--;
					}
				}
			}

			// этап 4
			// переписываем число в u
			BN u(divider.len + 1);
			u.len = divider.len + 1;
			for (int i = 0; i < divider.len + 1; i++)
			{
				u.coef[i] = divisible.coef[j + i];
			}

			// проверка на уменьшение q`
			if (u < divider * (BASE)(q))
			{
				q--;
			}

			// отнимаем от числа найденное q и делитель
			u = u - divider * (BASE)(q);
			result.coef[j] = (BASE)(q);

			// перезапишем u
			// этап 5
			// денормализация
			for (int i = 0; i < divider.len + 1; i++)
			{
				divisible.coef[j + i] = u.coef[i];
			}

			j--; // этап 6
		}

		result.len_norm();

		return result;
	}

	BN operator%(const BASE &x)
	{
		int j = 0;
		DBASE tmp = 0;
		BASE r = 0;
		BN result(1);

		while (j < this->len)
		{
			tmp = ((DBASE)r << BASE_SIZE) + (DBASE)this->coef[this->len - 1 - j];
			r = (BASE)(tmp % (DBASE)x);

			j++;
		}

		result.coef[0] = r;
		return result;
	}

	BN operator%(const BN &x)
	{
		if (x.len == 1 && x.coef[0] == 0)
		{
			throw invalid_argument("Invalid arguments.");
		}
		if (*this < x)
		{
			return *this;
		}

		if (x.len == 1)
		{
			return *this % x.coef[0];
		}

		int m = len - x.len;
		int base_size = BASE_SIZE;
		DBASE b = ((DBASE)(1) << (base_size));
		BASE d = (BASE)((DBASE)(b) / (DBASE)((x.coef[x.len - 1]) + (BASE)(1)));
		int j = m;
		int k = 0;

		BN divisible = *this;
		// увеличили на разряд
		divisible *= d;
		BN divider = x;
		divider *= d;

		// если не увеличилось на разряд
		if (divisible.len == len)
		{
			divisible.maxlen++;		// сравниваем длину нормализованного с исходным
			divisible.len = maxlen; // увеличваем len для ноля
			divisible.coef = new BASE[maxlen];
			delete[] divisible.coef;
			for (int i = 0; i < len; i++)
			{
				divisible.coef[i] = coef[i];
			}
			divisible *= d;
			divisible.len++;
			divisible.coef[divisible.len - 1] = 0;
		}

		while (j > -1)
		{
			// по формулам считаем q` и r` (q` - результаты делений и r` - остатки)
			// этап 3

			DBASE q = (DBASE)((DBASE)((DBASE)((DBASE)(divisible.coef[j + divider.len]) * (DBASE)(b)) + (DBASE)(divisible.coef[j + divider.len - 1])) / (DBASE)(divider.coef[divider.len - 1]));
			DBASE r = (DBASE)((DBASE)((DBASE)((DBASE)(divisible.coef[j + divider.len]) * (DBASE)(b)) + (DBASE)(divisible.coef[j + divider.len - 1])) % (DBASE)(divider.coef[divider.len - 1]));

			// проверки на уменьшение q`
			if (q == b || (DBASE)((DBASE)(q) * (DBASE)(divider.coef[divider.len - 2])) > (DBASE)((DBASE)((DBASE)(b) * (DBASE)(r)) + (DBASE)(divisible.coef[j + divider.len - 2])))
			{
				q--;
				r = (DBASE)(r) + (DBASE)(divider.coef[divider.len - 1]);
				if ((DBASE)(r) < b)
				{
					if (q == b || (DBASE)((DBASE)(q) * (DBASE)(divider.coef[divider.len - 2])) > (DBASE)((DBASE)((DBASE)(b) * (DBASE)(r)) + (DBASE)(divisible.coef[j + divider.len - 2])))
					{
						q--;
					}
				}
			}

			// этап 4
			// переписываем число в u
			BN u(divider.len + 1);
			u.len = divider.len + 1;
			for (int i = 0; i < divider.len + 1; i++)
			{
				u.coef[i] = divisible.coef[j + i];
			}

			// ещё одна проверка на уменьшение q`
			if (u < divider * (BASE)(q))
			{
				q--;
			}

			// отнимаем от числа найденное q` и делитель
			u = u - (divider * (BASE)(q));

			// компенсирующее сложение
			// этап 5
			for (int i = 0; i < divider.len + 1; i++)
			{
				divisible.coef[j + i] = u.coef[i];
			}

			j--;
		}
		divisible.len_norm();

		// um достаточно поделить на d
		return divisible / d;
	}

	int getL() { return len; }
	int getM() { return maxlen; }
	BASE getC(int i) { return coef[i]; }

	friend ostream &operator<<(ostream &, BN &);
	friend istream &operator>>(istream &, BN &);
};

ostream &operator<<(ostream &out, BN &bn)
{
	BN result = bn;
	BN zero(bn.len);

	string s;
	zero.len = result.len;

	while (result != zero)
	{
		BN tmp;
		tmp = result % 10;

		s.push_back(tmp.coef[0] + '0');

		result = result / 10;
		zero.len = result.len;
	}

	reverse(s.begin(), s.end());
	out << s << endl;

	return out;
}

istream &operator>>(istream &in, BN &bn)
{
	int x = 0, i = 0, t = 0;
	char s[100];
	cin >> s;
	delete[] bn.coef;

	bn.len = (strlen(s) - 1) / (BASE_SIZE / 4) + 1;
	bn.maxlen = bn.len;
	bn.coef = new BASE[bn.maxlen]{};

	while (i < strlen(s))
	{
		t = s[i] - '0';
		bn = bn * (BASE)10 + (BASE)t;
		i++;
	}

	while (bn.coef[bn.len - 1] == 0 && (bn.len > 1))
		bn.len--;

	return in;
}

/*
srand(time(0));

	BN A(5,1);
	BN B(4,1);

	cout << A << endl;
	cout << B << endl;

	BN C = A / B;
	cout << C << endl;

	BN D = A % B;
	cout << D << endl;

*/

int main()
{

	srand(time(0));

	BN A(5, 1);
	BN B(4, 1);

	cout << A << endl;
	cout << B << endl;

	BN F = A * B;

	BN C = F / A;
	BN D = F % A;
	BN S = C + D;
	cout << (S == B) << endl;

	/*
	BN A;
	BN B;
	cin >> A;
	cin >> B;

	BN C = A / B;
	cout << C;

	BN D = A % B;
	cout << D;
	*/

	// BN A(5,1);
	// BN B(4,1);

	// cout << A << endl;
	// cout << B << endl;

	// BN C = A / 241;
	// cout << C << endl;

	// BN D = A % 241;
	// cout << D << endl;
}