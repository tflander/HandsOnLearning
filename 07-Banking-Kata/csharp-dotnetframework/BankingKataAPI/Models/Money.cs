using System;
using System.Globalization;

public sealed class Money : IEquatable<Money>, IComparable, IComparable<Money>
{

	private static int[] cents = new int[] { 1, 10, 100, 1000 };

	CultureInfo cultureInfo;

	RegionInfo regionInfo;

	long amount;
    public Guid id { get; private set; }

    public Money() : this(0, CultureInfo.CurrentCulture) { }

	public Money(decimal amount) : this(amount, CultureInfo.CurrentCulture) { }

	public Money(long amount) : this(amount, CultureInfo.CurrentCulture) { }

	public Money(string cultureName) : this(new CultureInfo(cultureName)) { }

	public Money(decimal amount, string cultureName) : this(amount, new CultureInfo

		(cultureName))
	{ }

	public Money(CultureInfo cultureInfo) : this(0, cultureInfo) { }

	public Money(decimal amount, CultureInfo cultureInfo)
	{

		if (cultureInfo == null) throw new ArgumentNullException("cultureInfo");

		this.cultureInfo = cultureInfo;

		this.regionInfo = new RegionInfo(cultureInfo.LCID);

		this.amount = Convert.ToInt64(Math.Round(amount * CentFactor));

	}

	public Money(long amount, CultureInfo cultureInfo)
	{

		if (cultureInfo == null) throw new ArgumentNullException("cultureInfo");

		this.cultureInfo = cultureInfo;

        this.regionInfo = RegionInfo.CurrentRegion;

		this.amount = amount * CentFactor;

	}

	private int CentFactor
	{

		get { return cents[cultureInfo.NumberFormat.CurrencyDecimalDigits]; }

	}

	public string EnglishCultureName
	{

		get { return cultureInfo.Name; }

	}

	public string ISOCurrencySymbol
	{

		get { return regionInfo.ISOCurrencySymbol; }

	}

	public decimal Amount
	{

		get { return amount / CentFactor; }

	}

	public int DecimalDigits
	{

		get { return cultureInfo.NumberFormat.CurrencyDecimalDigits; }

	}

	public static bool operator >(Money first, Money second)
	{

		AssertSameCurrency(first, second);

		return first.amount > second.amount;

	}

	public static bool operator >=(Money first, Money second)
	{

		AssertSameCurrency(first, second);

		return first.amount >= second.amount;

	}

	public static bool operator <=(Money first, Money second)
	{

		AssertSameCurrency(first, second);

		return first.amount <= second.amount;

	}

	public static bool operator <(Money first, Money second)
	{

		AssertSameCurrency(first, second);

		return first.amount < second.amount;

	}

	public static Money operator +(Money first, Money second)
	{

		AssertSameCurrency(first, second);

		return new Money(first.Amount + second.Amount, first.EnglishCultureName);

	}

	public static Money operator -(Money first, Money second)
	{

		AssertSameCurrency(first, second);

		return new Money(first.Amount - second.Amount, first.EnglishCultureName);

	}

	public static Money Add(Money first, Money second)
	{

		return first + second;

	}


	public static implicit operator Money(decimal amount)

	{

		return new Money(amount, CultureInfo.CurrentCulture);

	}

	public static implicit operator Money(long amount)
	{

		return new Money(amount, CultureInfo.CurrentCulture);

	}

	public override bool Equals(object obj)
	{

		return (obj is Money) && Equals((Money)obj);

	}

	public override int GetHashCode()
	{

		return amount.GetHashCode() ^ cultureInfo.GetHashCode();

	}

	private static void AssertSameCurrency(Money first, Money second)
	{

		if (first.ISOCurrencySymbol != second.ISOCurrencySymbol)

			throw new InvalidOperationException("Money type mismatch.");

	}

	public bool Equals(Money other)
	{

		if (object.ReferenceEquals(other, null)) return false;

		return ((ISOCurrencySymbol == other.ISOCurrencySymbol) &&

			(amount == other.amount));

	}

	public static bool operator ==(Money first, Money second)
	{

		if (object.ReferenceEquals(first, second)) return true;

		if (object.ReferenceEquals(first, null) || object.ReferenceEquals(second, null))

			return false;

		return (first.ISOCurrencySymbol == second.ISOCurrencySymbol &&

			first.Amount == second.Amount);

	}

	public static bool operator !=(Money first, Money second)
	{

		return !first.Equals(second);

	}

	public static Money operator *(Money money, decimal value)
	{

		if (money == null) throw new ArgumentNullException("money");

		return new Money(Decimal.Floor(money.Amount * value), money.EnglishCultureName);

	}

	public static Money Multiply(Money money, decimal value)
	{

		return money * value;

	}

	public static Money operator /(Money money, decimal value)
	{

		if (money == null) throw new ArgumentNullException("money");

		return new Money(money.Amount / value, money.EnglishCultureName);

	}

	public static Money Divide(Money first, decimal value)
	{

		return first / value;

	}

	public Money Copy()
	{

		return new Money(Amount, cultureInfo);

	}

	public Money Clone()
	{

		return new Money(cultureInfo);

	}

	public int CompareTo(object obj)
	{

		if (obj == null)
		{

			return 1;

		}

		if (!(obj is Money))
		{

			throw new ArgumentException("Argument must be money");

		}

		return CompareTo((Money)obj);

	}

	public int CompareTo(Money other)
	{

		if (this < other)
		{

			return -1;

		}

		if (this > other)
		{

			return 1;

		}

		return 0;

	}

	public Money[] Allocate(long[] ratios)
	{

		return Allocate(ratios, CultureInfo.CurrentCulture);

	}

	//Foemmel’s Conundrum test from Martin Fowler’s

	//Patterns of Enterprise Application Architecture

	public Money[] Allocate(long[] ratios, CultureInfo cultureInfo)
	{

		if (ratios == null) throw new ArgumentNullException("ratios");

		long total = 0;

		for (int i = 0; i < ratios.Length; i++) total += ratios[i];

		long remainder = amount;

		Money[] results = new Money[ratios.Length];

		for (int i = 0; i < results.Length; i++)
		{

			results[i] = new Money(Amount * ratios[i] / total, cultureInfo);

			remainder -= results[i].amount;

			for (int j = 0; j < remainder; j++)
			{

				results[i].amount++;

			}

		}

		return results;

	}

	public override string ToString()
	{

		return Amount.ToString("C", cultureInfo);

	}

	public string ToString(string format)
	{

		return Amount.ToString(format, this.cultureInfo);

	}

	public static Money LocalCurrency
	{

		get { return new Money(CultureInfo.CurrentCulture); }

	}

}
