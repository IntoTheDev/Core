using Sirenix.OdinInspector;
using System;

namespace Sirenix.OdinInspector
{
	[IncludeMyAttributes]
	[ListDrawerSettings(NumberOfItemsPerPage = 1, Expanded = true)]
	public class PageList : Attribute { }
}