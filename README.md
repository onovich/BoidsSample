# Boids Sample
![](https://github.com/onovich/BoidsSample/blob/main/Assets/Resources_Sample/cover_boids.jpg)

I first encountered the Boids algorithm in April 2021 and was fascinated by it. Later that same year, during the GMTK GameJam, I created a game [Flow](https://github.com/onovich/Flow/tree/main) based on the algorithm, receiving a lot of feedback.<br/>
**我在 2021 年 4月 第一次接触到 Boids 算法并为之着迷。随后在同一年的 GMTK GameJam 上，我做了基于 Boids 算法的一个游戏 [Flow](https://github.com/onovich/Flow/tree/main)，获得了很多人的反馈。**

At that time, my development skills were quite low, and driven solely by enthusiasm, I managed to complete the game in 4 days (the code was a piece of shit, and now I can't understand it at all). <br/>
**当时我的开发水平很低，全凭着一腔热情，4 天时间竟然也把游戏给做完了（完全没有开发规范，现在去看代码已经完全看不懂了）。**

Over the years, I have often thought about this game. With increased knowledge and improved development habits, I always wonder, "Would I do it better if I remade it now?" <br/>
**这之后的几年里我也一直回想起这个游戏，随着认知的增加和开发习惯的改善，我总会好奇「如果现在的我去重新制作它，会不会做得更好」。**

Based on this, I started a new project [Air](https://github.com/onovich/Air), but I am not in a hurry to push it forward. <br/>
**基于这一点，我开了一个新的项目 [Air](https://github.com/onovich/Air)，但并不急于推进。**

Recently, I spent two days rewriting the Boids algorithm and extracted it from Air, removing the gameplay-related parts, for reference implementation only.<br/>
**现在我花了两天时间重新编写了 Boids 算法的部分，并把它从 Air 中抽出来，移除玩法相关的部分，仅供实现参考。**

Version 0.0.1 shows an implementation based on the grid method.<br/>
**0.0.1 版本可以看到基于网格法的实现。**

Version 0.0.2 switched to Compute Shader, running 1000 Boids on screen without any pressure.<br/>
**0.0.2 版本改为 Compute Shader，全屏跑 1000 个 Boids 无压力。**

The latest version has removed parts unrelated to Boids for better readability.<br/>
**最近的版本移除了和 Boids 无关的部分，以便更好地阅读。**
