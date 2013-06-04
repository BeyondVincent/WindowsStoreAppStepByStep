namespace CxxCXNumberComponent
{
    public ref class Number sealed
    {
    public:

        Number() : _value(0) { }

        int GetValue()           { return _value;  }
        void SetValue(int value) { _value = value; }

    private:

        int _value;
    };
}
