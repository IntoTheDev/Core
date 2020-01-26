using Sirenix.OdinInspector;
using System;

namespace Sirenix.OdinInspector
{
	[IncludeMyAttributes]
	[ListDrawerSettings(NumberOfItemsPerPage = 1, Expanded = true, DraggableItems = false)]
	public class PageList : Attribute { }
}