#include "pch.h"

#include "WRLNumberComponent_h.h"
#include <wrl.h>

using namespace Microsoft::WRL;
using namespace Windows::Foundation;

namespace ABI
{
	namespace WRLNumberComponent
	{
		class WinRTClass: public RuntimeClass<IWinRTClass>
		{
			InspectableClass(L"WRLNumberComponent.WinRTClass", BaseTrust)

			public:
			WinRTClass()
			{
			}
		};

		ActivatableClass(WinRTClass);
	}
}