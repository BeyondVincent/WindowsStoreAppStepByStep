#include "WRLNumberComponent_h.h"

#include <wrl.h>

using ABI::WRLNumberComponent::INumber;
using Microsoft::WRL::RuntimeClass;

class Number : public RuntimeClass<INumber>
{
    InspectableClass(RuntimeClass_WRLNumberComponent_Number, BaseTrust)

public:

    Number() : _value(0) { }

    virtual HRESULT STDMETHODCALLTYPE GetValue(INT32* value) override
    {
        *value = _value;
        return S_OK;
    }

    virtual HRESULT STDMETHODCALLTYPE SetValue(INT32 value) override
    {
        _value = value;
        return S_OK;
    }

private:

    INT32 _value;
};

ActivatableClass(Number)
