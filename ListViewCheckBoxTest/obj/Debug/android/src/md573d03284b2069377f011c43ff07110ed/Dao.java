package md573d03284b2069377f011c43ff07110ed;


public class Dao
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ListViewCheckBoxTest.Dao, ListViewCheckBoxTest", Dao.class, __md_methods);
	}


	public Dao ()
	{
		super ();
		if (getClass () == Dao.class)
			mono.android.TypeManager.Activate ("ListViewCheckBoxTest.Dao, ListViewCheckBoxTest", "", this, new java.lang.Object[] {  });
	}

	public Dao (java.lang.String p0, boolean p1)
	{
		super ();
		if (getClass () == Dao.class)
			mono.android.TypeManager.Activate ("ListViewCheckBoxTest.Dao, ListViewCheckBoxTest", "System.String, mscorlib:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}

	public Dao (int p0, java.lang.String p1, boolean p2)
	{
		super ();
		if (getClass () == Dao.class)
			mono.android.TypeManager.Activate ("ListViewCheckBoxTest.Dao, ListViewCheckBoxTest", "System.Int32, mscorlib:System.String, mscorlib:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
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
