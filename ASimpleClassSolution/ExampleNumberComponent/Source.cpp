
typedef CxxCXNumberComponent::Number CxxCxNumber;
typedef WRLNumberComponent::Number   WRLNumber;

int main(Platform::Array<Platform::String^>^ args)
{
    // Create an instance of the Number class from the WinRT component implemented using C++/CX:
    CxxCxNumber^ cxxCxNumber = ref new CxxCxNumber();
    cxxCxNumber->SetValue(42);
    int cxxCxValue = cxxCxNumber->GetValue();

    // Create an instance of the Number class from the WinRT component implemented using WRL:
    WRLNumber^ wrlNumber = ref new WRLNumber();
    wrlNumber->SetValue(42);
    int wrlValue = wrlNumber->GetValue();
}
