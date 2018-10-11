namespace AudioPlayer
{
    internal class Lyrics
    {
        public string Dlyrics(string title)
        {
            switch (title)
            {
                case "GOD'S PLAN":
                    return
                        "Yeah they wishin\' and wishin\' and wishin\' and wishin\'\r\nThey wishin\'" +
                        " on me, yuh\r\nI been movin\' calm, don\'t start no trouble with me\r\n" +
                        "Tryna keep it peaceful is a struggle for me\r\nDon’t pull up at 6 AM to " +
                        "cuddle with me\r\nYou know how I like it when you lovin\' on me\r\nI don’t" +
                        " wanna die for them to miss me\r\nYes I see the things that they wishin\'" +
                        " on me\r\nHope I got some brothers that outlive me\r\nThey gon\' tell the story, shit was different with me";
                case "IDGAF":
                    return
                        "You call me all friendly\r\nTellin\' me how much you miss me\r\nThat\'s" +
                        " funny, I guess you\'ve heard my songs\r\nWell, I\'m too busy for your" +
                        " business\r\nGo find a girl who wants to listen\r\n\'Cause if you think I" +
                        " was born yesterday\r\nYou have got me wrong";
                case "PSYCHO":
                    return
                        "Damn, my AP goin\' psycho, lil\' mama bad like Michael\r\nCan\'t really" +
                        " trust nobody with all this jewelry on you\r\nMy roof look like a no-show," +
                        " got diamonds by the boatload\r\nCome with the Tony Romo for clowns and all " +
                        "the bozos\r\nMy AP goin\' psycho, lil\' mama bad like Michael\r\nCan\'t really" +
                        " trust nobody with all this jewelry on you\r\nMy roof look like a no-show, got " +
                        "diamonds by the boatload\r\nDon\'t act like you my friend when I\'m rollin\'" +
                        " through my ends, though";
                default:
                    return "Lyrics no found";
            }
        }
    }
}