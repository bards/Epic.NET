
	function getStyleDictionary() {
	
		var dictionary = new Array();
		return(dictionary);

	}

	function toggleVisibleLanguage(id) {

        if (id == 'cs') {
			sd['span.cs'].display = 'inline';
			sd['span.vb'].display = 'none';
			sd['span.cpp'].display = 'none';
        } else if (id == 'vb') {
			sd['span.cs'].display = 'none';
			sd['span.vb'].display = 'inline';
			sd['span.cpp'].display = 'none';
		} else if (id == 'cpp') {
			sd['span.cs'].display = 'none';
			sd['span.vb'].display = 'none';
			sd['span.cpp'].display = 'inline';
		} else {
		}

	}

