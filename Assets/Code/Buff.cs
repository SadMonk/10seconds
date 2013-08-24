using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface Buff {	
	int getType();
	void enable(Player player);
	void checkEnd();	
	
}
