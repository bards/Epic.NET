
	function SplitScreen (nonScrollingRegionId, scrollingRegionId) {

		// store references to the two regions
		this.nonScrollingRegion = document.getElementById(nonScrollingRegionId);
		this.scrollingRegion = document.getElementById(scrollingRegionId);

	}

	SplitScreen.prototype.resize = function(e) {
	}
