using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface Buff {
	
	void getType();
	void enable(Player player);
	void checkEnd();	
	
}
