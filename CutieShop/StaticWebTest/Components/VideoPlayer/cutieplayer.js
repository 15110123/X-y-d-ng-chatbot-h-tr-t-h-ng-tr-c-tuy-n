(function (cjs, an) {

var p; // shortcut to reference prototypes
var lib={};var ss={};var img={};
lib.ssMetadata = [];


// symbols:
// helper functions:

function mc_symbol_clone() {
	var clone = this._cloneProps(new this.constructor(this.mode, this.startPosition, this.loop));
	clone.gotoAndStop(this.currentFrame);
	clone.paused = this.paused;
	clone.framerate = this.framerate;
	return clone;
}

function getMCSymbolPrototype(symbol, nominalBounds, frameBounds) {
	var prototype = cjs.extend(symbol, cjs.MovieClip);
	prototype.clone = mc_symbol_clone;
	prototype.nominalBounds = nominalBounds;
	prototype.frameBounds = frameBounds;
	return prototype;
	}


(lib.an_Video = function(options) {
	this._element = new $.an.Video(options);
	this._el = this._element.create();
	var $this = this;
	this.addEventListener('added', function() {
		$this._lastAddedFrame = $this.parent.currentFrame;
		$this._element.attach($('#dom_overlay_container'));
	});
}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(0,0,400,300);

p._tick = _tick;
p._handleDrawEnd = _handleDrawEnd;
p._updateVisibility = _updateVisibility;



(lib.timelineDot = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#000000").s().p("AgGAHQgDgDAAgEQAAgDADgDQADgDADAAQAEAAADADQADADAAADQAAAEgDADQgDADgEAAQgDAAgDgDg");
	this.shape.setTransform(41.6,4.4);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#4E342E").s().p("AAQBFIgFgnIgoAAIAAAnIgUAAIAAgpIgqgHIgKArIgTgKIAJgnIgjgRIAGgTIAsAVIA6AKIA4AAIAvgSIAmgdIAggfQAHAIAFAIIgYAYIAXAhIgPAPIgXgjIgaASIATApIgSALIgSgrIgiAOIAFArg");
	this.shape_1.setTransform(18,13.1);

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.f("#5D4037").s().p("AgpBNIg8gKIgBAAIgsgWIAGgTIAlASIAghAIgXgWIAQgNIAYAYIA0AJIAsgkIAIgSQALACAIAEIgHARIAxA4IAYgYQAHAJAFAIIgeAdIgBAAIAAABIgoAeIg0AVIgEAAgAAHA5IgOg8IgugHIgfA8IAuAHIAtAAgAALgIIAQA+IAmgPIAegXIgug2g");
	this.shape_2.setTransform(18,8.3);

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.f("#8D6E63").s().p("AglBLIg8gKIgtgWQAOgzArghQArghA2AAQAoAAAjATQAiASAWAgIgfAeIgoAeIgyAUg");
	this.shape_3.setTransform(17.8,7.5);

	this.shape_4 = new cjs.Shape();
	this.shape_4.graphics.f("#795548").s().p("AhgBkIg8geIAAgKQAAhBAwgvQAugvBBAAQA2AAArAgQApAgAPAxQgoA4hCAcIgGACg");
	this.shape_4.setTransform(18.7,10);

	this.shape_5 = new cjs.Shape();
	this.shape_5.graphics.f().s("#558B2F").ss(4,1,0,4).p("AgRgnIgUAnIAOAUQAWAUArAA");
	this.shape_5.setTransform(9.8,22);

	this.shape_6 = new cjs.Shape();
	this.shape_6.graphics.f().s("#558B2F").ss(4,1,0,4).p("AgsgnIAsABQAtADAAAGQAAATgPAaQgHAOgIAK");
	this.shape_6.setTransform(27.5,22);

	this.shape_7 = new cjs.Shape();
	this.shape_7.graphics.f("#558B2F").s().p("AgNAPQgGgHAAgIQAAgHAGgGQAFgGAIAAQAIAAAGAGQAGAGAAAHQAAAIgGAHQgGAFgIAAQgIAAgFgFg");
	this.shape_7.setTransform(41,5);

	this.shape_8 = new cjs.Shape();
	this.shape_8.graphics.f("#C0CA33").s().p("AhuAPQgNAAgJgJQgIgHAAgNIEZAAQgCANgJAIQgJAIgMAAg");
	this.shape_8.setTransform(19.1,21.5);

	this.shape_9 = new cjs.Shape();
	this.shape_9.graphics.f("#8BC34A").s().p("AgFAMIAFgRIACgSQAAgGAEgFQAEgEAHAAQAHAAAEAEQAEAEABAHIgBAFIAAACIgLAUIgPARQgRARgVABQARgHAKgUg");
	this.shape_9.setTransform(3.3,19.1);

	this.shape_10 = new cjs.Shape();
	this.shape_10.graphics.f("#8BC34A").s().p("AhtBVQgMgMAAgRQAAgQAMgMQALgLARgBQA3gDAYgNQAfgQAKgsQAGgcAYgGQAOgDAZAEQAOADAAAOIgFAeQgNBIgrAhQgtAihhADQgRAAgLgLg");
	this.shape_10.setTransform(33.8,11.8);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_10},{t:this.shape_9},{t:this.shape_8},{t:this.shape_7},{t:this.shape_6},{t:this.shape_5},{t:this.shape_4},{t:this.shape_3},{t:this.shape_2},{t:this.shape_1},{t:this.shape}]}).wait(1));

}).prototype = getMCSymbolPrototype(lib.timelineDot, new cjs.Rectangle(0,0,46.1,28), null);


(lib.timelineBar = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#F7931E").s().p("Egq+ACMIAAkXMBV9AAAIAAEXg");
	this.shape.setTransform(275.1,14);

	this.timeline.addTween(cjs.Tween.get(this.shape).wait(1));

}).prototype = getMCSymbolPrototype(lib.timelineBar, new cjs.Rectangle(0,0,550.2,28), null);


(lib.soundDot = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#2196F3").ss(0.1,1,1).p("ABaAAQAAAmgaAaQgaAagmAAQglAAgagaQgagaAAgmQAAglAagaQAagaAlAAQAmAAAaAaQAaAaAAAlg");
	this.shape.setTransform(9,9);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#2196F3").s().p("Ag/A/QgagaAAglQAAglAagaQAbgaAkAAQAlAAAbAaQAaAaAAAlQAAAlgaAaQgbAbglAAQgkAAgbgbg");
	this.shape_1.setTransform(9,9);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).wait(1));

}).prototype = getMCSymbolPrototype(lib.soundDot, new cjs.Rectangle(-1,-1,20,20), null);


(lib.soundBar = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#999999").ss(0.1,1,1).p("AoWgsIQtAAIAABZIwtAAg");
	this.shape.setTransform(53.5,4.5);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#FFFFFF").s().p("AoWAtIAAhZIQtAAIAABZg");
	this.shape_1.setTransform(53.5,4.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).wait(1));

}).prototype = getMCSymbolPrototype(lib.soundBar, new cjs.Rectangle(-1,-1,109,11), null);


(lib.playButton = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#FFFFFF").s().p("ADgAfQgUi1hQgVIgKgBQhugDiZC3Qg8BIgvBPQguBNgNAuQgFh+BPiOQBOidBdhUQBbhVBdAAQAVAAAUAEQBmAXApCUQAqCVg6CKQgfBXgvBMQAkh4gQiig");
	this.shape.setTransform(-0.3,-0.1,0.069,0.069);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#FFFFFF").s().p("Ak6CgQAAipBviPQBqiJBwAAQBuAABfBuQBfBvAACCQAAAegFAtQgXhIgxhGQhjiQh8AAQgpAAg4ArQg0AogwBCQhvCXABB9IABAOQgXhEAAg+g");
	this.shape_1.setTransform(-13.4,-0.2,0.069,0.069);

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.f("#FFFFFF").s().p("Ak6CPQAAilBUh6QBiiOCpAAQBqAABVBrQBXBvAACPQAABRgHBGQACieh3h3QgqgrgxgcQgqgYgVAAQhwAAhyCrQgsBEgeBIQgbBFAAAnIACAOQgahSAAg+g");
	this.shape_2.setTransform(-9.6,-6.1,0.069,0.069);

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.f("#FFFFFF").s().p("Ak6CJQAAiTBciAQBqiUCgAAQBdAABSBpQBgB6AAC6QAABIgLBKQgDiIhfiPQhbiHhIgFQh+ABhyCkQgvBDgdBLQgcBJAAA0IAAABQgNhTAAhDg");
	this.shape_3.setTransform(-3.7,-6.1,0.069,0.069);

	this.shape_4 = new cjs.Shape();
	this.shape_4.graphics.f("#FFFFFF").s().p("AtHGLQAAhLAcg3QAWguAzguQARgQBZhIQBMg9Azg0QAugvBLhZQBIhVAigjQB2h3B1AAQCFgBBtCLQAaAhBEBlQA9BbAsAyQAsA4BTAsQAOAICDA7QBUAmAkAiQAyAxAABEQgZgvhRgcQhtgehBgUQh3gmhUg7QhyhRhQiIQhJhuglgkQgugtgyAAQgwAAg4AxQgoAjhXBnQhOBbg0A2QgqAphPAsQgtAZheAvQhPApgmAkQgzAvgGA4g");
	this.shape_4.setTransform(-6.9,3.5,0.069,0.069);

	this.shape_5 = new cjs.Shape();
	this.shape_5.graphics.f("#FFFFFF").s().p("AiGGeQiEgfgliKQgpiWBoi8QBXivBohVQBohUBlAWQBmAWApCVQApCVg6CKQhDC8hwBoQhdBVheAAQgZAAgZgGg");
	this.shape_5.setTransform(-0.3,0.7,0.069,0.069);

	this.shape_6 = new cjs.Shape();
	this.shape_6.graphics.f("#FFFFFF").s().p("AjkEcQhWh6AAiFQAAioBviPQBqiJBwAAQBuAABfBuQBfBvAACDQAAC+hVCRQhaCYiHAAQiIAAhhiIg");
	this.shape_6.setTransform(-13.4,0.7,0.069,0.069);

	this.shape_7 = new cjs.Shape();
	this.shape_7.graphics.f("#FFFFFF").s().p("AjcESQgrhJgahUQgZhQAAg9QAAimBUh6QBiiOCpAAQBqAABVBrQBXBvAACQQAADrg4CJQhICvigAAQiKAAhti1g");
	this.shape_7.setTransform(-9.6,-4.9,0.069,0.069);

	this.shape_8 = new cjs.Shape();
	this.shape_8.graphics.f("#FFFFFF").s().p("Aj9ERQg9ilAAitQAAiTBciBQBqiUCgAAQBdAABSBpQBgB6AAC7QAADghYCgQhhC1ijAAQiNAAhPjZg");
	this.shape_8.setTransform(-3.7,-4.6,0.069,0.069);

	this.shape_9 = new cjs.Shape();
	this.shape_9.graphics.f("#FFFFFF").s().p("AsGG3QhBhGAAhfQAAhKAbg3QAXgvAyguQASgPBZhHQBLg9A0g1QAtgwBMhYQBIhWAigjQB2h3B1AAQCEAABuCLQAaAgBEBlQA9BcAsAyQAsA4BTAsQAOAICEA7QBTAmAkAiQAyAwAABFQAACDhOA7QhNA8ipABQhcAAivgiQiugihjAAQhgAAiiAwQiiAwhuAAQiOAAhOhWg");
	this.shape_9.setTransform(-6.9,4.3,0.069,0.069);

	this.shape_10 = new cjs.Shape();
	this.shape_10.graphics.f("#2196F3").s().p("EgmggmgMBNBAmgMhNBAmhg");
	this.shape_10.setTransform(0,0,0.075,0.075);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_10},{t:this.shape_9},{t:this.shape_8},{t:this.shape_7},{t:this.shape_6},{t:this.shape_5},{t:this.shape_4},{t:this.shape_3},{t:this.shape_2},{t:this.shape_1},{t:this.shape}]}).wait(1));

}).prototype = getMCSymbolPrototype(lib.playButton, new cjs.Rectangle(-18.4,-18.5,37,37), null);


(lib.pauseButton = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#2196F3").s().p("EgLeAmSMAAAhMjIW9AAMAAABMjg");
	this.shape.setTransform(27.7,18.5,0.076,0.076);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#2196F3").s().p("EgLeAmSMAAAhMjIW9AAMAAABMjg");
	this.shape_1.setTransform(5.5,18.5,0.076,0.076);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).wait(1));

}).prototype = getMCSymbolPrototype(lib.pauseButton, new cjs.Rectangle(0,0,33.3,37), null);


(lib.controlBar = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#333333").s().p("Egq+AD7IAAn1MBV9AAAIAAH1g");
	this.shape.setTransform(275.1,25.1);

	this.timeline.addTween(cjs.Tween.get(this.shape).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(0,0,550.2,50.2);


// stage content:
(lib.cutieplayer = function(mode,startPosition,loop) {
if (loop == null) { loop = false; }	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_0 = function() {
		this.timelineDot.x = 0;
		
		this.playButton.addEventListener("click", playClickHandler.bind(this));
		this.pauseButton.addEventListener("click", pauseClickHandler.bind(this));
		this.timelineBar.addEventListener("click", timelineBarClickHandler.bind(this));
		this.soundDot.addEventListener("pressmove", soundDotPressMoveHandler.bind(this));
		
		function playClickHandler() {
			this.pauseButton.visible = true;
			this.playButton.visible = false;
			$("#mainClip")[0].play();
			$('#mainClip').on('timeupdate', () => {
				this.timelineDot.x = $('#mainClip')[0].currentTime / $('#mainClip')[0].duration * 546;
			});
			$('#mainClip').on('ended', () => {
				this.pauseButton.visible = false;
				this.playButton.visible = true;
			});
		}
		
		
		function pauseClickHandler() {
			this.pauseButton.visible = false;
			this.playButton.visible = true;
			$("#mainClip")[0].pause();
		}
		
		function timelineBarClickHandler() {
			//Coordinate can be changed by browser resize as coor = preCoor * scale
			let mousePos = stage.mouseX / stage.scaleX;
			$('#mainClip')[0].currentTime = mousePos / 546 * $('#mainClip')[0].duration;
		}
		
		//Sound
		function soundDotPressMoveHandler() {
			let newX = stage.mouseX / stage.scaleX;
			if (newX > 176 || newX < 67) return;
			this.soundDot.x = newX;
			$('#mainClip')[0].volume = (this.soundDot.x - 67) / 109;
		}
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(1));

	// Layer_3
	this.soundDot = new lib.soundDot();
	this.soundDot.name = "soundDot";
	this.soundDot.parent = this;
	this.soundDot.setTransform(175,374.4,1,1,0,0,0,9,9);
	new cjs.ButtonHelper(this.soundDot, 0, 1, 1);

	this.soundBar = new lib.soundBar();
	this.soundBar.name = "soundBar";
	this.soundBar.parent = this;
	this.soundBar.setTransform(122.5,374.7,1,1,0,0,0,53.5,4.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.soundBar},{t:this.soundDot}]}).wait(1));

	// flash0.ai
	this.playButton = new lib.playButton();
	this.playButton.name = "playButton";
	this.playButton.parent = this;
	this.playButton.setTransform(29.5,375.7);
	new cjs.ButtonHelper(this.playButton, 0, 1, 1);

	this.timeline.addTween(cjs.Tween.get(this.playButton).wait(1));

	// flash0.ai
	this.pauseButton = new lib.pauseButton();
	this.pauseButton.name = "pauseButton";
	this.pauseButton.parent = this;
	this.pauseButton.setTransform(27.7,375.7,1,1,0,0,0,16.6,18.5);
	this.pauseButton.visible = false;
	new cjs.ButtonHelper(this.pauseButton, 0, 1, 1);

	this.timeline.addTween(cjs.Tween.get(this.pauseButton).wait(1));

	// flash0.ai
	this.timelineDot = new lib.timelineDot();
	this.timelineDot.name = "timelineDot";
	this.timelineDot.parent = this;
	this.timelineDot.setTransform(23,337,1,1,0,0,0,23,14);

	this.timeline.addTween(cjs.Tween.get(this.timelineDot).wait(1));

	// Layer_2
	this.instance = new lib.controlBar("synched",0);
	this.instance.parent = this;
	this.instance.setTransform(275.2,374.1,1,1,0,0,0,275.1,25.1);

	this.timeline.addTween(cjs.Tween.get(this.instance).wait(1));

	// Layer_1
	this.timelineBar = new lib.timelineBar();
	this.timelineBar.name = "timelineBar";
	this.timelineBar.parent = this;
	this.timelineBar.setTransform(275.2,335.1,1,1,0,0,0,275.1,14);
	new cjs.ButtonHelper(this.timelineBar, 0, 1, 1);

	this.mainClip = new lib.an_Video({'id': 'mainClip', 'src':'https://github.com/mediaelement/mediaelement-files/blob/master/echo-hereweare.mp4?raw=true', 'autoplay':false, 'controls':false, 'muted':false, 'loop':false, 'poster':'https://fthmb.tqn.com/jmqCh_LgA1bMcoBDQQqx91HPpaA=/1280x853/filters:fill(auto,1)/a0047-000145-56a2bce25f9b58b7d0cdf7cf.jpg', 'preload':true, 'class':'video'});

	this.mainClip.setTransform(275.1,160.5,1.376,1.07,0,0,0,200,150);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.mainClip},{t:this.timelineBar}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(274.3,199.5,551.6,399.7);
// library properties:
lib.properties = {
	id: '4538E71C36F8A3449A9A15E7A037F814',
	width: 550,
	height: 400,
	fps: 50,
	color: "#FFFFFF",
	opacity: 1.00,
	manifest: [
		{src:"https://code.jquery.com/jquery-2.2.4.min.js", id:"lib/jquery-2.2.4.min.js"},
		{src:"components/sdk/anwidget.js", id:"sdk/anwidget.js"},
		{src:"components/video/src/video.js", id:"an.Video"}
	],
	preloads: []
};



// bootstrap callback support:

(lib.Stage = function(canvas) {
	createjs.Stage.call(this, canvas);
}).prototype = p = new createjs.Stage();

p.setAutoPlay = function(autoPlay) {
	this.tickEnabled = autoPlay;
}
p.play = function() { this.tickEnabled = true; this.getChildAt(0).gotoAndPlay(this.getTimelinePosition()) }
p.stop = function(ms) { if(ms) this.seek(ms); this.tickEnabled = false; }
p.seek = function(ms) { this.tickEnabled = true; this.getChildAt(0).gotoAndStop(lib.properties.fps * ms / 1000); }
p.getDuration = function() { return this.getChildAt(0).totalFrames / lib.properties.fps * 1000; }

p.getTimelinePosition = function() { return this.getChildAt(0).currentFrame / lib.properties.fps * 1000; }

an.bootcompsLoaded = an.bootcompsLoaded || [];
if(!an.bootstrapListeners) {
	an.bootstrapListeners=[];
}

an.bootstrapCallback=function(fnCallback) {
	an.bootstrapListeners.push(fnCallback);
	if(an.bootcompsLoaded.length > 0) {
		for(var i=0; i<an.bootcompsLoaded.length; ++i) {
			fnCallback(an.bootcompsLoaded[i]);
		}
	}
};

an.compositions = an.compositions || {};
an.compositions['4538E71C36F8A3449A9A15E7A037F814'] = {
	getStage: function() { return exportRoot.getStage(); },
	getLibrary: function() { return lib; },
	getSpriteSheet: function() { return ss; },
	getImages: function() { return img; }
};

an.compositionLoaded = function(id) {
	an.bootcompsLoaded.push(id);
	for(var j=0; j<an.bootstrapListeners.length; j++) {
		an.bootstrapListeners[j](id);
	}
}

an.getComposition = function(id) {
	return an.compositions[id];
}

function _updateVisibility(evt) {
	if((this.getStage() == null || this._off || this._lastAddedFrame != this.parent.currentFrame) && this._element) {
		this._element.detach();
		stage.removeEventListener('drawstart', this._updateVisibilityCbk);
		this._updateVisibilityCbk = false;
	}
}
function _handleDrawEnd(evt) {
	var props = this.getConcatenatedDisplayProps(this._props), mat = props.matrix;
	var tx1 = mat.decompose(); var sx = tx1.scaleX; var sy = tx1.scaleY;
	var dp = window.devicePixelRatio || 1; var w = this.nominalBounds.width * sx; var h = this.nominalBounds.height * sy;
	mat.tx/=dp;mat.ty/=dp; mat.a/=(dp*sx);mat.b/=(dp*sx);mat.c/=(dp*sy);mat.d/=(dp*sy);
	this._element.setProperty('transform-origin', this.regX + 'px ' + this.regY + 'px');
	var x = (mat.tx + this.regX*mat.a + this.regY*mat.c - this.regX);
	var y = (mat.ty + this.regX*mat.b + this.regY*mat.d - this.regY);
	var tx = 'matrix(' + mat.a + ',' + mat.b + ',' + mat.c + ',' + mat.d + ',' + x + ',' + y + ')';
	this._element.setProperty('transform', tx);
	this._element.setProperty('width', w);
	this._element.setProperty('height', h);
	this._element.update();
}

function _tick(evt) {
	var stage = this.getStage();
	stage&&stage.on('drawend', this._handleDrawEnd, this, true);
	if(!this._updateVisibilityCbk) {
		this._updateVisibilityCbk = stage.on('drawstart', this._updateVisibility, this, false);
	}
}


})(createjs = createjs||{}, AdobeAn = AdobeAn||{});
var createjs, AdobeAn;