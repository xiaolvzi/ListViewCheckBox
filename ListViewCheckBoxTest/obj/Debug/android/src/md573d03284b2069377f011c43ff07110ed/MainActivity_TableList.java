package md573d03284b2069377f011c43ff07110ed;


public class MainActivity_TableList
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ListViewCheckBoxTest.MainActivity+TableList, ListViewCheckBoxTest", MainActivity_TableList.class, __md_methods);
	}


	public MainActivity_TableList ()
	{
		super ();
		if (getClass () == MainActivity_TableList.class)
			mono.android.TypeManager.Activate ("ListViewCheckBoxTest.MainActivity+TableList, ListViewCheckBoxTest", "", this, new java.lang.Object[] {  });
	}

	public MainActivity_TableList (java.lang.String p0, boolean p1)
	{
		super ();
		if (getClass () == MainActivity_TableList.class)
			mono.android.TypeManager.Activate ("ListViewCheckBoxTest.MainActivity+TableList, ListViewCheckBoxTest", "System.String, mscorlib:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
