# BowlingScoreCalculator

Route: /api/scores

++Request: 

Headers
 Authorization : Basic c2NvcmVjYWxjdWxhdG9yOnNjb3JlY2FsY3VsYXRvcg==
 
 Body
  {
    "pinsDowned" : ["10","10","10","10","10","10","10","10","10","10","10","10"]
  }
  
  ++Response
  
  "frameProgressScores": ["30", "60", "90", "120", "150", "180", "210", "240", "270", "300"],
   "gameCompleted": true
}
  
