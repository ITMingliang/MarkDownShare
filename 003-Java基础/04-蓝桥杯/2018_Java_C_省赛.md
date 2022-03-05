# 第一题

标题：哪天返回

小明被不明势力劫持。后被扔到x星站再无问津。小明得知每天都有飞船飞往地球，但需要108元的船票，而他却身无分文。
他决定在x星战打工。好心的老板答应包食宿，第1天给他1元钱。
并且，以后的每一天都比前一天多2元钱，直到他有足够的钱买票。
请计算一下，小明在第几天就能凑够108元，返回地球。

要求提交的是一个整数，表示第几天。请不要提交任何多余的内容。

**解析：**

```
//模拟第一天的状态
int dayMoney = 1;  		//第一天工资1
int sumMoney = 1;           //第一天总共有钱1
//从第二天开始循环(最多工作108天)
for (int day = 2; day <= 108; day++) {
    dayMoney = dayMoney + 2;
    sumMoney = sumMoney + dayMoney;
    if(sumMoney >= 108)
    {
        System.out.println(day);  //打印答案
        break;
    }
}
```

```
答案：11
```

----------

# 第二题

标题：猴子分香蕉

5只猴子是好朋友，在海边的椰子树上睡着了。这期间，有商船把一大堆香蕉忘记在沙滩上离去。
第1只猴子醒来，把香蕉均分成5堆，还剩下1个，就吃掉并把自己的一份藏起来继续睡觉。
第2只猴子醒来，重新把香蕉均分成5堆，还剩下2个，就吃掉并把自己的一份藏起来继续睡觉。
第3只猴子醒来，重新把香蕉均分成5堆，还剩下3个，就吃掉并把自己的一份藏起来继续睡觉。
第4只猴子醒来，重新把香蕉均分成5堆，还剩下4个，就吃掉并把自己的一份藏起来继续睡觉。
第5只猴子醒来，重新把香蕉均分成5堆，哈哈，正好不剩！

请计算一开始最少有多少个香蕉。

需要提交的是一个整数，不要填写任何多余的内容。

**解析：**

```
int sum=  1;   //假设香蕉总个数
int num;        //香蕉在均分过程中的个数
while(true)
{
    num = sum;   //假设当前的香蕉总数
    boolean flag = true;   //假设当前数量是正确的
    for (int i = 1; i <= 4; i++)   //香蕉被分了5次，前4次分完后剩下1，2，3，4个香蕉
    {
        if(num >= 5 && num % 5 == i)  //正好复合分香蕉规律
        	num = num-num/5-i;  //计算分完剩下的香蕉
        else
        {
            flag = false;
            break;
        }
    }
    if(flag == true && num >= 5 && num%5 == 0)  //最后一次分香蕉的条件判断，正好分完
    {
        System.out.println(sum);  //打印答案
        break;
    }
    sum++;
}
```

```
答案：3141
```

-----------------------

# 第三题

标题：字母阵列

仔细寻找，会发现：在下面的8x8的方阵中，隐藏着字母序列："LANQIAO"。
SLANQIAO
ZOEXCCGB
MOAYWKHI
BCCIPLJQ
SLANQIAO
RSFWFNYA
XIFZVWAL
COAIQNAL

我们约定: 序列可以水平，垂直，或者是斜向；
并且走向不限（实际上就是有一共8种方向）。
上图中一共有4个满足要求的串

下面有一个更大的（100x100）的字母方阵。
你能算出其中隐藏了多少个“LANQIAO”吗？

```
FOAIQNALWIKEGNICJWAOSXDHTHZPOLGYELORAUHOHCZIERPTOOJUITQJCFNIYYQHSBEABBQZPNGYQTCLSKZFCYWDGOAIADKLSNGJ
GSOZTQKCCSDWGUWAUOZKNILGVNLMCLXQVBJENIHIVLRPVVXXFTHQUXUAVZZOFFJHYLMGTLANQIAOQQILCDCJERJASNCTLYGRMHGF
TSDFYTLVIBHKLJVVJUDMKGJZGNNSTPVLCKTOFMUEUFSVQIAUVHNVFTGBDDARPKYNNCUOYUAZXQJNOEEYKLFRMOEMHUKJTPETHLES
FKVINSLWEVGAGMKVFVIUBMYOIAFHLVNKNTYKTZWVXQWRWIGPENFXYDTKRVPKRTHMGHVYOCLDCKMEKRLGEKBYUCLOLYPAKPFSOREH
KWPUOLOVMOFBIXYACWRDYBINTMPASPCEOKHXQIGBQQMCEOIVULIEOPFSCSIHENAJCVDPJDOIWIIULFDNOZOFVAMCABVGKAKCOZMG
XWMYRTAFGFOCNHLBGNGOXPJSTWLZUNNAGIRETGXFWAQSSJPFTQAXMTQWMZWYVEPQERKSWTSCHSQOOBGXAQTBCHOEGBDVKGWJIFTG
ZWWJEIISPLMXIMGHOOGDRZFTGNDDWDWMNUFWJYJGULPHNUFSAQNNIUVAAFZIAZKFXXNWCEABGJAUMGYEIEFVQXVHHHEDYUITRCQB
XZHDPZQTOBECJVBZLACVXACZEDYOGVAVQRNWEOWGRAQYUEUESTEDQTYJUTEFOOITSHDDZHONJGBRCWNEQLZUTBNQIADKNFIOMWZR
EBFKCVNLURZSNPOLTISRPDTNUMCDGKTYRGIOVEPTUTSBAWQKWWEUWIWHAANUZUADGZEATZOQICWFUJTWNZDBKLQNELWVTBNDLNFH
PESISEATZNCDFRMXBQUKBFTIGYSFCWVHPMSUSDKPSCOMVLDOHYQVFHAJKRDTAVLIMNZBZSMLMRTLRPSLAHXDBASDMWAAYBPYVJZF
SCCWYHLQOUKBMCEYENQNJXFOMOOJMTKDSHJJOHDKEGATFZHGWJJAZJROWHAZUFGEQKPYXLCAAXHHQBDALPYUDWZQHBASBBCFGQCQ
ZKNXUBRYZVSPQHOVLAEUAUITMPWXNXJQVIBJVBCSVXKWFAFRPRWOLYVSDVTGGOFFMNQJZOBUDJLFHJTCYMPNOBHQJHGKLIKLZMLA
POCKVEQXUAVHERIAQLGJHYOOVOMTXQFRTBFSETOZICPCHZHFBWNESVJJLSVSVOOGYYABFESWNWDNYBGBNAKRCFQMTCUMIFTESVIN
JCAULIQRYUMAMAOVVWSEUTMECXSDTONRMMROQUISYEURSAYNZUVOPXLIFBDOHPXMABBLEQZGLJXQJOEYYRRRCFTEZQAOIWKRJQDL
ZNUUDWZXZZURPMHGXQGNQBIQWWNERZWULSAPIBODBFFQQIHEQKCKLJYQNXQUTAAYGRBXSLLQNOQPZJEWHETQHPXJANMJFOHINWOW
KJGAWWFSVIZHFNUWBLWYVPIWAEICCAHOEIWRADSLOZGPSVGPUBUUQAVYCHOIGINKYKJABWAQCZCXOBKTNJZQRHLUFKQLACAAOIWJ
SIKWLXQHKDFJVGBVXWDWJKUSFRQRTDJYQMNFOQQALHRLMHSDMCFLAOVKDMTKMTPVTLAZLYJNJXZCFRHHSDIXYUUSVIMIICLUJHFW
JHWUSMCFYHPIXHAPBBSHYDQCKVGQFTENLVERFVOVDCLSTQFUSEPUMTFODLZLYQXDOXAEPONIQWTDWSAWBNSZYACGSJQSHAUMIKXT
MVBNFXMFNPAYSODPXEAYNRKTEZJWMUACSIUYPIORUFPMXAOZZJPJXPFLNSKNIAMETMOVULZPQIJJIRCSYQXOEVRHCNACSBRHKYNW
KGKBTBHGWKVJYZCOVNSKUREKZEIWVLOHAMUAYKLUGHEUESICBZAHURNTJAECTHRNKSIJQFIPVZANSZYSPJWHPKHCAPEYWNXUYQSD
RRRFYQFIQSWYRQTSNGNUFOBMSLGAFWPJGYEHGASFKTJCCZPXFIQLSXNKNWCYVTETOAPCOZJNHEWOCCAWVDEZUQCLLAVUQJJTQCKJ
NMBKMUENVGXXVMQCLXPJDQIQCFWYADIFDSGINGZDJYHPUPXVRMWDIPJRWPNRYOFGYYPEAVKDEMLYRRRMNCRQXPTDSQIVKKGJWDEF
SBAEKIFZCKDOMIQKBDWVQGBYWPDIBOLQUGAQRXLJDAZMXVZXYSNWEWTNZKYREMBEUHOTFOCKEJSXCMUBCKXNGQXTQJRCRCLWJTOI
YXBFBIBRAAFNPKBLTSMCFERZURZNWHMOEHIHNQTBWXNPJGIDYDPRGEWACCBULJRACOFLANQIAOIHMYCNQHVKXSIGAMWAHUSNBBTD
QDGPTRONXHAZWOUPNBFJFEWAMFZUQZFDKAPNJUBQPWBPYGPZHKUDZZDLCCWHGAUKJCSLLFWGPYJKJQBNLCZESOGXXSQCVVKVRVAW
NXPGQOUEFLUZHHSAODIWEPZLXVQLYGVOOVCCREDJZJOMCSCFFKEIEAVCTPUZOWNOLJHGBJHJFBFFORGXOXXFOCAGBWEFCIDEKDLB
PTXSUINQAJURNFQPMMSPLZTQAHCIOFJUEFFZGIHTSJNIEXQLLHRQUXXLLORJEHGQJOXSLIAVFPEJNGMMVAXDDMPXLOSTRLLFLYRM
JQNCLENGTROIKDWBMXRNJYPGZRQOREPJJPTXKVVKPYYZENEOIQKZOPXAYGFXORXRIDGATHMZFDJIOIOKVDJBHSXQMYCBYFGXWHLH
CITGTILGPGBHZMNWWHXEFPGDPJUVFBJKAQWACZHPRPJYCOLGZTBDCVHNRSUAJUQAWAPMQJDQIFPZQZEONWHIYKMXDZOMVETEFJRB
RDOTIDCFEESOKYPYCGQQKOGPMGJRITSVTKOKDSXLRLJRRHNFRFXCMDNQMCEGZFJWHZOAFBQXXPXNBSWTSUYPAWQRHAUGLNPBRSJT
HOWRIUGMOQTUYIHDWJRFBWWKWYKCICSVBVKTBIIWGFSVIFCTUKIHHUUISCOTEOYRWQXTAEBXQQOLLMOALNIYVCCHNSWIKHMYYNZO
OFRIYYXPPSRTPAYMUJSSDILKIZAYSEIOLANQIAOVKARDPGVFCSYBSNHAPGTIKLAWTTKOEADWRLAACAAFYTBTNSGFTYLYUHJXBMMA
NJFTMLUIBKDPWBXQOMBVQXCZOIREHRSZCSJOIVBXWQIBUTYBQNTZRVROHGOIZYAJWXLEATLOZJIKJMIHSLGSVTCXJWIOOGWSERRQ
DBQJNGBLRIYFIKHBEYOZQBOAGGNIZKFDHWXCFNJLBQXVLHIQNIBZSDLTTRERHNWCMLJCVBBGGAQTPUQHIRABXPQSYGSDVMBNNDFG
KPLFUYXHYGOCZPPXMWCZYNKCYBCRZVKFBHQXPGPBZFTTGEPQTJMOFHAYSQQZDMQECGXOXADYHNNXUKNBXZBYHBOULXNBJZKIZREF
LVHAMSNXJOCVRPVGJUWXFVOCUCLCZDXRPBBDRLRAVVNLOZWOHWMXYSNMXAKJYWYGILNGUJGIPKAUDVANZLFWKUWWUSQYBRCBVDIJ
QCXPLOTPPGXCUZOUSSTXHVMLHVMJTUSSOPLRKEBQSGWNGVHKANVZWYQHSHLIPWSYCPKTUKPMWPLVFLLAHXZQANFXHFNYHIQVIOYN
ZPTJJCBHXPSUPOMNRVCKXSUFCNRCRNCPTPGIDQOEQUDFNUNMJPOEKVIMUJAJZOUKMAFSLDWYMCHTSNJYUDJAHQOIXPYSRHVAFFCR
DCGMEEWXWMNOSSJNIZCINRHENPPPCYVFWYCONOPKXMFZXXIHNXIGAHAMHSBRESOETGVXWDNQLGCEOUDDJXHQIVCHRNKBFFEWILGY
SOAIQNALXRBSGAQIDQVMVDKVZCPMJNXKXRXPFZAUVQPBHHQKTPDSQROLQTUGMFQRWGVEWCYPDYDZGNNNUFKJUEHJKPLIQNRQYXHU
GKGWUCJXUKAEHLRLNDFUQPSJAZTVJRXWXQVBMRJXULEMJJPDCVTOWVFDBVLSBHZRRQUVMUQYKTJCLSGGHGCPHPHMWYAECLJIZUWV
QQNKPQRJMSOCEAYDNKPHVEGKAGCKAPDXTGVXULHUXHJPDXCSKQTCJENVTZTMRUENCSWHBEORALSREBWAJEMQDXMRKGHJGICDHKHY
YNSDSWDRLBBFUFVVICMGUCGBSVDLJNXGKXNFGVLKAVBJRRRUHKRXTPBJAKIEBAVMDIOJLIUDABCGNPNJIYBCXMOOWKRPHPYSWRDC
BORWTNBISSLTVKBRTLWKRNCEDCNEGCIYJIPDICFAVNOISYAHWBLGMNFKXZYTTWJOBEPNMSJEJMHXVPGOJOLQQQVXFGEULANQIAOD
OQETOJHCZXGTUKIWGMEVVMXCURISUOFQSAWZWDMZWVYHZMPEIMWKJDGERODVVUXYRTYLCRGYQQOIOFZSSZRAIESWBQOAIQNALJNR
HEYWHPLLPCUEOCBAOWGAYEJZQJHLVNMVQNSQQGGUBOIMDPFLOVSQGBLYAMBRYJDVOXOQINLJAVYALAKHPKOYNKGXIISSJNGKHYMS
IQVRYKXCUFIRNENEXFJTMOTJWYXSMTDHHPRHWIXETWVVIXZELKLLWRWQYGBCGJNYSUQEFCOUDNIJMLJNLAWSYJGULKBCFPYVSSMW
WQHGWRQFWFOTGPBBSJBDUKOMBXNRPIMCGPGVZFADWTBVIEMVTBXVAFQDDMJALCOMZTXUFFKBQQZDFAMTFWEXTHBKNWRLUVITQXLN
OPPJQKNGHWWPENVQIABJCQNKXNPWOWRFEOKQPQLANQIAORGGOLAYCEGZBHZVLPBERWYIJNJUNXKULUQOJLTNRDZDEYWEMYCHJLLB
LJISOAQLXJEFXVTOZSICOLQIJEXUANJWIFSIMGUQWHBXUDWOEILYFUZTGDZDSPLZPDPXBLFAXLEFQFEPDSJQWEQMXKKHCXHMSATM
UMUJENPBYKZLWAJAXJKDIYCBREBPOETQHMRHLKSEZUIPRGWIZDDQLSJAPKPBWMJMPZWLNFLFCQOCDBMLIHIYCXUJLFLPZVGWBKMY
WHZJLKEWUPETVUREKVKCLBNYFLWCERVIPUDINNWGQTUHWXCTDVTMYATYUZLMVLOHKBOGIZCQDOWFBCWJAVUXYUEVRKPOXCKHAWZC
RPLNLCUHJRADHJNSDPZXIKXGUKEJZCFJQASVUBSNLXCJXVCJZXGMRYRLOBCNGPDUJQVEFKMYHNZGZOAIQNALQDHTBWJXPKJLFXJY
MKCEZEDAFGSOCORWJGMOKWPVVBVDYZDZHPXFWJBDELHPGOQHMBAHUUUJMGXAEKZCTQTBXNVYUIQUVZGXSKQXJWRUPSFIJDYIAORC
GKFKQNXPJWOPPBTUKTHUBIROSYOVFEMJBRREWICJPCIOSTWPAUSKTRQULXPWRSXHSRYBCWYCYOTCTPFSQLDIILIGMEVZKYSOYRPH
SFDSCSMLLNARCCGCBJOGZAEQTGNGSFAQIXLPDBSWZDTYVASYYPVBRFBTIAGGWONGSVKCJDBBLYKAIOXUATGMALZXFOHZFTXALCFU
CUSSTLCRYPDTFSFJFENKJWTEBOBEPLSNXLALQWCKSLVMZQDJITHZKVCCQXTEXOSVAUFYAZXJUOAPPVEEWOIIMOSZZMCOQBRUXWKG
PDOFSCKKJJTRYRWGLEZODQTJSIMXIAOLNMLPHBAYLPTTLPYWILSEIIQVSXNHIJEORVCNJHYXRBIZZJTADGMRTSXVRXYGVQQNUEIC
IHNJOQXUXTXFPALCHOELNVMWDWQTEARUKPIFWXJSMWZLMNLAODUTKNZDYRFRLGBLIBGIBXJBOYMLYLANQIAORORYKSJPOOOAMVRN
IWIUHLYJKTQGVJBDPROSRGZUFITDIBCDPICNEFIGHWGSROWBYKUCLCQYLJXLHLXSCTJWKDLHHMLDBZCVDKPXYYASHUUMUJMVSXAD
GXOYXQFEBFIEJJLHBNGSYALOUXNQBXXZAAZJXENJJVVGFVHOTKSLEGLJVSJCQHSSZFEIOGBOGWSPIRENQAAWRQFBEFEXBKGMSTRC
PYIANSGMNKBCDPHWDUPKICQEUDNZPNGRUJYSZIRLXGXXITAFBCANGDLVAQLDPVTJNSAUZMBBNOBBOERSHQIOLBVTSPPJKVCMXUBS
IKMDIYSNCJZKJKJQMTIKEPRUNAHJUSWJHSLWIVWHYAYLOIOGSZVWKQWXZDBPHWZRAIPMXDJHBIISVJWVEVZAEGAKCYYMNZARBZPC
DLDFVQDFDMVHYVOWEKMFKWUXLTPWIVKPRZZXOLMDAPAIQEKJHCHYAGJDBOFWDGNEGQGOOKWSKLTLREMGGTVJFHAIBCQKNZVRCZYS
FBQASGNCCBBGNKJHCDBTGBIIWKMPHDABKEWDEPYEAVKNMPATUZZUOEHGUGAZNECSGUCIIJPMMRAMTVADMTCRJCBWDLWWFNFOWMVZ
XFJFBGDAVGGAIZHAUIYENDZTRUWHPQUFWCHOXNCWYNAWVPLBLNQKQDTKQQKXNFXCTBGRWUZFHNRBDNLNKQVOLLGBBJQIYOBCEIKO
CURAGWXMLYBSIZLAXFONZZMQMRNNSRQKRHQGFGZUTLONAYRKSSOWAMKZBSGOOYQDPTBHGPBNQEDCZHRTOXREOFJEKJVIZXZBCJPN
KGYBZTZRKOGBETJRUWRNUCIFKIMCZGYTZLCZYGCGKVZRJIFZQIQPTCPPUHYWIXBOFFGSGSAIMNGKKUUROAVNJUQQNSWJRZIZEHAF
DDAOBVCPOVODVJFLSNPJXHWQBHILWZAHQQMTQASNADZLZNXJLJMFCOUWOZJCMVVTYCKTUBABWLCEBNYWAMOLNBQQYBRUJCQCZALE
TVVRPMYFIKINHIUEJBDLTCUMMUWICIUVCZNIQIUEWVAHLANQIAONMEYJWPDAFXVNOSOFDOCESSLGZPTJINBUAFWWWMPTYALZIGVD
DCZGKILMBFXIQQFEKJBIUDEMIFCANVGNYZAYSQFMNNQFEPZFUUVGTBKSMDXITBLANQIAOQUKTPNYPOWSQQYWWMJHSDYVFDJYXBAF
VGYXAMDRRZWVIHNQPZZWRNWBTROOJOLNUGXBILZKQEGIQSYGKZGODPWBJSCMRRWSSQURUFIAFQGEZLGZNOEQMNQEYUKPEQPPVAMO
SYSFUAJFKIPUJVQSZRWQCJYAUMLDDNOKODDXIEQIFLANQIAOZFUNKUBVDBLMJOAUTVCZVLKJRQIORQPGAVCEYVNYUZHXILHERYEC
GJEKWEKIJNIWUXZNVIWIAANHIOSOLATSQFSSCTAKESUTSPPYFHEHLVLIBJZEEBCOWMNHFTZMAPKFUPNFLTFFJQRVJHAKDVMGGUIX
KAKXXNKSOAIQNALLWKWGVACYWBQEVTFSEUCYRORQTHWFUJFLQHONWZEKPLSNPRPBOMOFFCPMKXFZBKIERBKDYFKYUEYVYRPMOAQI
WNICDLQKZXGTKDLIEFBGELGJOAIQNALXZLGGDQIBVEULDPBWUJNTYOKFBPGMAWRRUJPPIGYCNYURNOSQRIRBAZAGWWDUHAAZQWPT
KFXZQXRMKSBUXWOUVVHSJWTLKZELGXMMAIDSJIWGCJPCBWZIEKMNUPUAFHTUMOZKJWVTIAQNOHELEMWGKJHKPNJVSRVHAUFXBUOU
XOWCZJYQLXJRUOOYSKDLDXKWTTJBYBTLKSWRUYPOYTPBGUJXBMRWNELBWADCSZDAEEFGPVRHNNLBFDDXNPDXLKQUSJAZDEUDBMBD
QIKYEKMVUHGGWZDKXFVQQNECZOAWCFUBHQMEPEPKEFSDBAYJQOSGAIHRBRAUKLQRANKMTTIOJDDXAEWTQHIYSGRRMEFTNNWCLZSI
ZFUQAQCSFNVUQMKUQWBWFQIEQVVXPOSVIDTUOBLLTGHQKEMSUWWHWRISLGRDPPQPZBANSGDWXKNYTKMWECPMPDYSCJZXPUKPWGYI
CNGVLBSCBHRLJARWSRENGHYYQDKRATERCPEAOPAJZUMOYIDHVPDMQPKKHCBAMRBGEIEXXJALMCXKPUGXYVINRORFYURXAMOJCBZQ
YJHHAWESCLMDIHVYMLAJZQSYTDEURWYPOLJCAKIKSATGVIALBLWPPKDEGSPMRLDBQNVPPCLQXKUQLQJERMYFGAETUATEBQZUMGUN
NBWUBVXYDFPLPJYLIDFVTVKKGFWMXVINLJUDUPABTSBJAJENZSXIMUJQWPEZTAVDMBBHFYTJKYFXIXQTBTTQIKQXQDPWYNMXRQDJ
OGWLZQUBJJHAQNPVRGHGPNMMJPIDGANYEEDWYPOLKLNEPYSRTQYCJLSWFRJRRGGSNSDHIXYYSNAKKBWQDDGYYMOGPUXQEUSAPSOU
CLLSELRVFZUFYVTJQKCQHNICMERWQFQNPVRPIIYKHZWJYJAFCLNSZXUHSPOZWQUMJHLKKYJENVZOCSWCTPYWIZONUUCLSUROGAYS
AZGNIMXPLPCEPULRRBHHQOBELHJZPUQAMWUASVKDXVEWAOFMAYSJFXHCNEUXUQWUESFBRUFZQLKKWHCHKOPLECCBYSLECAEZIMMI
TUUEOCEBAUKWLTSYJJPLZTIARAOZXKYYWIOXBBTZZCSAULKNEJWVQXIKUWBIWVHGNTHVBAWAVPGLHSDJDLPVHHHUNVSFKXARXLVQ
EMVDFSLANQIAOPTLFLFRKGNUZCTXWCAXHECTZFHWUFENRGQICHTYLSHZWIEGLNVDJZOMTKAAUWOHVOVOCTUKOSINSAYIAEUYORNA
VGPRMLCAQZIPRFQOZMEFTQZYVOTVFNVOIQSJCIPPQXQKJIXICUIGMHAJJMSXENCBQFIJHNZXIQMWACKDKQSEWWKMLOAUPFHAZGRY
SQWQMRSQBGGKYKGWEZYRIHWGNXRPOUMFSFGTYDLUDWPWAVQORTMQUXWKUQVNMDPWQFIZPOIHCJATODRQGZDMQXZVNXXVEJNGWZOM
PVBGZSQPCELDIWDHOQWAUHILGLPYRIICTLFSOYKQZYZOCIZPTECSWOODGGBDTSGIMYGMVPJPRPEVWOOKYFWRGXHWUCRQNYJEMSYL
XWOFXFVDXPTHYTCEGMODCILAHYBREZVVHOUPZKCNHUEVPMKHUBNRPFMWXVQACVZCALZLYMZSBLCEASPMIEFOTGKMPGWYQADSNDPR
QPHAVLZDZLKIEISFLLVWXAVBZLZIJRHGROUVGXRDLUJAXNHBBZYNCVERJGSKLWZEKGJBCWMSMLYIHZFFMIOGVIMZQBSRHQWAADYN
MNXEGTDXCDKIUDOISQXEUJWETPELKBCYFSDNJQWNNBPYMWBUPQBAAINMYZOYCEGNLFNNHZFEMSQVXJJGWBCRAVKZFWFBKMBRVBFD
HKACSZIUWUXLWKFPKOCUQJEPQDZCMUJFLVCLIOQQRVKSWFIAKNHMRLNJTKGVNTGLCVPVMBLJANOBCXUGVWBJYSIXZQVAVFWILWFB
QWNLTPMCYHRSKVHXLONRANWKWXUTHYQLIOFKGDBMSWDRCYRKVSAGGRJMWQYQFLMUIGGCLAUQAACTYLPZEOJBHMWRKHCRXGTGRMUP
CPQKJRBLYDNPUGHCRBVYBAIRVCAWLBWVWCMKNBIRKJOUGYQEBQRHDSTWXDIWGRVMLIJFBWHLHCDAAVUDLZSCGQNOUXVUIVIZZZMD
NMHGYPFUUDWKQGTAKKGCDFJFYJFNRZVXDPGZEAMWQVQZODKTXHIYFVKJSSAWVHYCUCZMLLBPXTILDYJQEMWDRUFKISOUVPUDTYPB
FDAQUBXHUJYTAYNWVIJNUSQDTQDEMUAPWXRYUWONTBDZCHZOUEGPMWEZTQWWSHAYOBWVTDIMZYNVNZKUHOFCQKPHJXWNRCGUJEKO
WSDAUGUTVWCVHEMOIRJJGTANUWTSAIXXEVZTBDHPGSRHHVWCDZVZYRJTLONIJVXEATHQXOUKBIGZONFRSZIOGWNTYAJYLQCGEOWY
```

请提交一个整数，不要填写任何多余的内容。

**解析一：**

```
String lq = "LANQIAO";  //定义需要搜索匹配的字符串
char[][] arrChar = new char[100][100]; //定义100*100数组存放字符串
Scanner input = new Scanner(System.in);
//利用循环将字符串填充至数组，原始字符串正好以回车进行的每行分隔,
//所以只需要将原始字符串一次输入就等于100次输入
System.out.println("请将原始字符串复制粘贴到下方:");
for (int i = 0; i < 100; i++) {
	arrChar[i] = input.nextLine().toCharArray();
}
//定义二维数组保存8个移动方向的下标移动变化规律，从上开始，顺时针定义
int[][] arrMove = new int[][]{{0,-1},{1,-1},{1,0},{1,1},{0,1},{-1,1},{-1,0},{-1,-1}};
int result = 0;   //记录符合条件的次数
//循环所有字符
for (int i = 0; i < arrChar.length; i++) 
{
	for (int j = 0; j < arrChar[i].length; j++) 
	{
		if(arrChar[i][j] == lq.charAt(0))   //循环过程中发现字符为"L",则进行细节判断
		{
			//以此字符为中心，向8个方向去找复合条件的情况，循环arrMove的一维
			for (int k = 0;k < arrMove.length; k++) 
			{
				int rowIndex = i; //记录当前行号
				int colIndex = j;  //记录当前列号
				boolean flag = true;  //假设可以找到"LANQIAO"
				//向每个方向需要找6次,第一个L不需要查找
				for (int m = 1; m < lq.length(); m++) 
				{
					rowIndex = rowIndex + arrMove[k][0];
					colIndex = colIndex + arrMove[k][1];
					//在移动过程中下标超出界限，一定找不到符合条件的
					if(rowIndex < 0 || rowIndex >= 100 || colIndex < 0 || colIndex >= 100)
					{
						flag = false;  break;
					}
					//移动过程中将移动的出来的字符和"LANQIAO"中字符一个一个比较,不相等则退出
					if(arrChar[rowIndex][colIndex] != lq.charAt(m))
					{
						flag = false; break;
					}
				}
				//6次比对循环完成后flag值如果仍然为true，则证明符合条件
				if(flag == true)
					result++;
			}
		}
	}
}
System.out.println(result); //打印最后结果
```

```
答案：41
```

备注：上述方案使用二维数组存储8个方向，除此之外，也可以定义一个类来存储方向，如下解析：

**解析二：**

```
class MyDirection
{
	int x;
	int y;
	public MyDirection(int x,int y)
	{
		this.x = x;
		this.y = y;
	}
}
public class Demo03 
{
	public static void main(String[] args)
	{
		String lq = "LANQIAO";  //定义需要搜索匹配的字符串
		char[][] arrChar = new char[100][100]; //定义100*100数组存放字符串
		Scanner input = new Scanner(System.in);
		//利用循环将字符串填充至数组，原始字符串正好以回车进行的每行分隔,
		//所以只需要将原始字符串一次输入就等于100次输入
		System.out.println("请将原始字符串复制粘贴到下方:");
		for (int i = 0; i < 100; i++) {
			arrChar[i] = input.nextLine().toCharArray();
		}
		//定义对象数组保存8个移动方向的下标移动变化规律，从上开始，顺时针定义
		MyDirection[] arrMove = new MyDirection[8];
		arrMove[0] = new MyDirection(0,-1);
		arrMove[1] = new MyDirection(1,-1);
		arrMove[2] = new MyDirection(1,0);
		arrMove[3] = new MyDirection(1,1);
		arrMove[4] = new MyDirection(0,1);
		arrMove[5] = new MyDirection(-1,1);
		arrMove[6] = new MyDirection(-1,0);
		arrMove[7] = new MyDirection(-1,-1);	
		int result = 0;   //记录符合条件的次数
		//循环所有字符
		for (int i = 0; i < arrChar.length; i++) 
		{
			for (int j = 0; j < arrChar[i].length; j++) 
			{
				if(arrChar[i][j] == lq.charAt(0))   //循环过程中发现字符为"L",则进行细节判断
				{
					//以此字符为中心，向8个方向去找复合条件的情况，循环arrMove的一维
					for (int k = 0;k < arrMove.length; k++) 
					{
						int rowIndex = i; //记录当前行号
						int colIndex = j;  //记录当前列号
						boolean flag = true;  //假设可以找到"LANQIAO"
						//向每个方向需要找6次,第一个L不需要查找
						for (int m = 1; m < lq.length(); m++) 
						{
							rowIndex = rowIndex + arrMove[k].x;
							colIndex = colIndex + arrMove[k].y;
							//在移动过程中下标超出界限，一定找不到符合条件的
							if(rowIndex < 0 || rowIndex >= 100 || colIndex < 0 || colIndex >= 100)
							{
								flag = false;  break;
							}
							//移动过程中将移动的出来的字符和"LANQIAO"中字符一个一个比较,不相等则退出
							if(arrChar[rowIndex][colIndex] != lq.charAt(m))
							{
								flag = false; break;
							}
						}
						//6次比对循环完成后flag值如果仍然为true，则证明符合条件
						if(flag == true)
							result++;
					}
				}
			}
		}
		System.out.println(result); //打印最后结果		
	}
}
```



# 第四题

标题：第几个幸运数

到x星球旅行的游客都被发给一个整数，作为游客编号。
x星的国王有个怪癖，他只喜欢数字3,5和7。
国王规定，游客的编号如果只含有因子：3,5,7,就可以获得一份奖品。

我们来看前10个幸运数字是：
3 5 7 9 15 21 25 27 35 45
因而第11个幸运数字是：49

小明领到了一个幸运数字 59084709587505，他去领奖的时候，人家要求他准确地说出这是第几个幸运数字，否则领不到奖品。

请你帮小明计算一下，59084709587505是第几个幸运数字。

需要提交的是一个整数，请不要填写任何多余内容。

**解析：**

```
long max = 59084709587505L;
int count = 0;
for (long i = 0; Math.pow(3, i) < max; i++)
{
	for (long j = 0; Math.pow(5, j) < max; j++)
	{
		for (long k = 0; Math.pow(7, k) < max; k++)
		{
			if (Math.pow(3, i) * Math.pow(5, j) * Math.pow(7, k) < max)
			{
				count++;
			}
		}
	}
}
System.out.println(count);
```

```
答案：1905
```

备注：只含有因子：3,5,7，即最后结果，只能由3，5，7或者3，5，7相互乘法得到的结果。

此计算由于在循环中存在i,j,k都等于0的时候，即最后结果为1，此情况应该不符合题目条件，即比小明数字小的所有符合条件的数字的次数应该是count-1,题目问的是小明是第几位，所以最后结果应该是count-1+1=count。

--------------------

# 第五题

标题：书号验证

2004年起，国际ISBN中心出版了《13位国际标准书号指南》。
原有10位书号前加978作为商品分类标识；校验规则也改变。
校验位的加权算法与10位ISBN的算法不同，具体算法是：
用1分别乘ISBN的前12位中的奇数位（从左边开始数起），用3乘以偶数位，乘积之和以10为模，10与模值的差值再对10取模（即取个位的数字）即可得到校验位的值，其值范围应该为0~9。

下面的程序实现了该算法，请仔细阅读源码，填写缺失的部分。

```
public class A
{
	static boolean f(String s){
		int k=1;
		int sum = 0;
		for(int i=0; i<s.length(); i++){
			char c = s.charAt(i);
			if(c=='-' || c==' ') continue;
			sum += ______________________________;  //填空
			k++;
			if(k>12) break; 
		}
		
		return s.charAt(s.length()-1)-'0' == (10-sum % 10)%10;
	}
	
	public static void main(String[] args){
		System.out.println(f("978-7-301-04815-3"));
		System.out.println(f("978-7-115-38821-6"));
	}
}
```

注意：只提交空缺的代码，不要抄写已经存在的代码。

**解析：**

```
k%2==1?Integer.parseInt(c+""):3*Integer.parseInt(c+"")
```

备注：此题只需要关注“用1分别乘ISBN的前12位中的奇数位（从左边开始数起），用3乘以偶数位，乘积之和”这句话即可，后面的内容在下面的代码进行了实现，填空部分只需要求和。

---------------

# 第六题

标题：打印大X

如下的程序目的是在控制台打印输出大X。
可以控制两个参数：图形的高度，以及笔宽。

用程序中的测试数据输出效果：

```
高度=15, 笔宽=3
***           ***
 ***         ***
  ***       ***
   ***     ***
    ***   ***
     *** ***
      *****
       ***
      *****
     *** ***
    ***   ***
   ***     ***
  ***       ***
 ***         ***
***           ***
高度=8, 笔宽=5
*****  *****
 **********
  ********
   ******
   ******
  ********
 **********
*****  *****
```

上图效果显示如果不清晰，可以看如下图片：

![1](img\1.png)

请仔细分析程序流程，填写缺失的代码。

```
public class A
{
	static void f(int h, int w){
		System.out.println(String.format("高度=%d, 笔宽=%d",h,w));
		int a1 = 0;
		int a2 = h - 1;
		
		for(int k=0; k<h; k++){
			int p = Math.min(a1,a2);
			int q = Math.max(a1+w,a2+w);
			
			for(int i=0; i<p; i++) System.out.print(" ");
			
			if(q-p<w*2){
				____________________________________________ ; //填空
			}
			else{
				for(int i=0; i<w; i++) System.out.print("*");
				for(int i=0; i<q-p-w*2; i++) System.out.print(" ");
				for(int i=0; i<w; i++) System.out.print("*");
			}
			System.out.println();
			a1++;
			a2--;
		}
	}
	
	public static void main(String[] args){
		f(15,3);
		f(8,5);
	}
}
```

注意：只填写缺失的代码，不要拷贝已经存在的代码。

**解析：**

```
for(int i = 0; i < q-p; i++)  System.out.print("*")
```

-----------

# 第七题

标题：缩位求和

在电子计算机普及以前，人们经常用一个粗略的方法来验算四则运算是否正确。
比如：248 * 15 = 3720
把乘数和被乘数分别逐位求和，如果是多位数再逐位求和，直到是1位数，得
2 + 4 + 8 = 14 ==> 1 + 4 = 5;
1 + 5 = 6
5 * 6
而结果逐位求和为 3
5 * 6 的结果逐位求和与3符合，说明正确的可能性很大！！（不能排除错误）

请你写一个计算机程序，对给定的字符串逐位求和：
输入为一个由数字组成的串，表示n位数(n<1000);
输出为一位数，表示反复逐位求和的结果。

例如：
输入：
35379

程序应该输出：
9

再例如：
输入：
7583676109608471656473500295825

程序应该输出：
1


资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 1000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
不要使用package语句。不要使用jdk1.7及以上版本的特性。
主类的名字必须是：Main，否则按无效代码处理。

**解析：**

```
Scanner input  = new Scanner(System.in);
char[] arr = input.nextLine().toCharArray();
while(true)
{
	int sum = 0;
	for (int i = 0; i < arr.length; i++) {
		sum = sum + (arr[i]-'0');
	}
	arr = (sum+"").toCharArray();
	if(sum <= 9)
	{
		System.out.println(sum);
		break;
	}
}
```

---------------------------------

# 第八题

标题：等腰三角形

本题目要求你在控制台输出一个由数字组成的等腰三角形。
具体的步骤是：
1. 先用1,2,3，...的自然数拼一个足够长的串
2. 用这个串填充三角形的三条边。从上方顶点开始，逆时针填充。
比如，当三角形高度是8时：

![2](img\2.png)

输入，一个正整数n(3<n<300),表示三角形的高度
输出，用数字填充的等腰三角形。

为了便于测评，我们要求空格一律用"."代替。

例如：
输入：
5

程序应该输出：
....1
...2.1
..3...2
.4.....1
567891011

再例如：
输入：
10

程序应该输出：
.........1
........2.2
.......3...2
......4.....2
.....5.......1
....6.........2
...7...........0
..8.............2
.9...............9
1011121314151617181

再例如：
输入：
15

程序应该输出：

..............1
.............2.3
............3...2
...........4.....3
..........5.......1
.........6.........3
........7...........0
.......8.............3
......9...............9
.....1.................2
....0...................8
...1.....................2
..1.......................7
.1.........................2
21314151617181920212223242526

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 1000ms

**解析：**

```
Scanner input  = new Scanner(System.in);
int high = input.nextInt();  //输入三角形高度
//long start=System.currentTimeMillis();
char[][] arr = new char[high][2*high-1];
//为二维数组每个元素赋值.
for (int i = 0; i < arr.length; i++) {
	for (int j = 0; j < arr[i].length; j++) {
		arr[i][j] = '.';
	}
}
//根据高度求总字符个数,2*h-3=两斜边的字符个数总和,2*h-1为底边的字符个数
int charCount = 2*high-3 + 2*high-1;  //求总共字符个数
String str = "";
//用循环将所有数字组合转换成字符串，最多循环次数应该是字符总个数
for (int i = 1; i <= charCount; i++) 
{
	str += i+"";
	if(str.length() >= charCount)  //字符串长度大于等于总字符个数的时候退出
	{
		str = str.substring(0, charCount);
		break;
	}				
}
int index = 0;  //保存数字字符串当前的下标
//给左斜边填充
int x = 0;
int y = high-1;		
for (int i = 1; i <= high-1; i++) {
	arr[x][y] = str.charAt(index++);
	x++;
	y--;
}
//给底部填充
x = high-1;
y = 0;
for (int i = 1; i <= 2*high-1; i++) {
	arr[x][y] = str.charAt(index++);
	y++;
}
//给右斜边填充,从右下向左上填充，最后一个字符不需要填充
x=high-2;
y=2*high-3;
for (int i = 1; i <= high-2; i++) {
	arr[x][y] = str.charAt(index++);
	x--;
	y--;
}		
//嵌套循环打印结果
for (int i = 0; i < arr.length; i++) {
	for (int j = 0; j < arr[i].length; j++) {
		if(j <= i+high-1)  	//程序右边的点不用打印
			System.out.print(arr[i][j]);
	}
	System.out.println();
}

//long end=System.currentTimeMillis(); //获取结束时间		 
//System.out.println("程序运行时间： "+(end-start)+"ms");
```

---------------

# 第九题

标题：小朋友崇拜圈

班里N个小朋友，每个人都有自己最崇拜的一个小朋友（也可以是自己）。
在一个游戏中，需要小朋友坐一个圈，
每个小朋友都有自己最崇拜的小朋友在他的右手边。
求满足条件的圈最大多少人？

小朋友编号为1,2,3,...N
输入第一行，一个整数N（3<N<100000）
接下来一行N个整数，由空格分开。

要求输出一个整数，表示满足条件的最大圈的人数。

例如：
输入：
9
3 4 2 5 3 8 4 6 9

则程序应该输出：
4

解释：
如图p1.png所示，崇拜关系用箭头表示，红色表示不在圈中。
显然，最大圈是[2 4 5 3] 构成的圈

![p1](img\3.png)

再例如：
输入：
30
22 28 16 6 27 21 30 1 29 10 9 14 24 11 7 2 8 5 26 4 12 3 25 18 20 19 23 17 13 15

程序应该输出：
16

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 1000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
不要使用package语句。不要使用jdk1.7及以上版本的特性。
主类的名字必须是：Main，否则按无效代码处理。

**解析：**

解题思路如下：
1、找规律理解崇拜关系,将一行整数存入数组arr，假设当前数组元素值为num,则a崇拜的人为arr[num-1]。
2、定义变量max保存最长崇拜圈。
3、遍历数组进行寻找，找到崇拜的人存入集合中且集合内未有重复元素则计数器加1
4、每次遍历后比较计数器count和max，将最大的数保存为max。
5、输出max。

```
Scanner input = new Scanner(System.in);
int sum = input.nextInt(); //输入总人数
int[] arr = new int[sum];
//输入n个整数存入数组
for (int i = 0; i < arr.length; i++) {
	arr[i] = input.nextInt();
}
int max = 0;  //假设最长崇拜圈人数为0
//遍历数组，以每个数组元素为起点，不停找崇拜的人
for (int i = 0; i < arr.length; i++) {
	int num = arr[i]; //获取当前数字
	int count = 0; //记录当前崇拜圈人数
	List<Integer> listInt = new ArrayList<Integer>();  //定义集合保存崇拜圈元素
	while(true)
	{
		if(listInt.contains(num))   //当在集合中找到了元素，证明崇拜圈结束
			break;
		listInt.add(num);  //将当前人，加入崇拜圈集合
		num = arr[num-1]; //将当前人崇拜的人，设置为当前，在通过while循环继续向后查找
		count++;  //当前崇拜圈人数+1
		if(count > max)
			max = count;
	}
}
System.out.println(max);
```

-----------

# 第十题

如果已知了测试塔的高度，并且采用最佳策略，在最坏的运气下最多需要测试多少次才能确定手机的耐摔指数呢？

输入数据，一个整数n（3<n<10000）,表示测试塔的高度。
输出一个整数，表示最多测试多少次。

例如：
输入：
3

程序应该输出：
2

解释：
手机a从2楼扔下去，坏了，就把b手机从1楼扔；否则a手机继续3层扔下

再例如：
输入：
7

程序应该输出：
3

解释：
a手机从4层扔，坏了，则下面有3层，b,c 两部手机2次足可以测出指数；
若是没坏，手机充足，上面5,6,7 三层2次也容易测出。

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 1000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
不要使用package语句。不要使用jdk1.7及以上版本的特性。
主类的名字必须是：Main，否则按无效代码处理。

---------------------------------
笨笨有话说：
我觉得3个手机太难了，要是2个手机还可以考虑一下。

歪歪有话说：
想什么呢，你！要是1部手机还用你编程啊？那样的话只好从下往上一层一层测。

**解析：**

```
Scanner input = new Scanner(System.in);
int fNum = input.nextInt();   //输入楼层高度
int pNum = 3;   //手机数量为3
//定义二维数组，pNum+1行,fNum+1列，+1因为我们从下标1开始使用数组，使用更加方便
//行和列交叉的值保存最终测试次数，例如arr[2][4]里面存储2部手机4层楼需要测试几次。
//题目实际上是要得到数组最后一个元素值，但是我们必须存储所有元素值，因为数组后面的值需要根据前面的值计算出来
int[][] arr = new int[pNum+1][fNum+1];  
for (int i = 1; i < arr.length; i++) {
	for (int j = 1; j < arr[i].length; j++) {
		//如果是只有1楼，那么测试数量就是1
		//如果只有一部手机，楼层数量就是测试数量，
		//并且手机数量越多，测试数量肯定越少，
		//如此赋值后，第一行和第一列是正确的值，其它数组元素值是所有方案中的最大值。
		arr[i][j] = j;
	}
}
//需要理解的部分：
//假设pNum个手机，fNum层楼，开始从任意一层X层丢手机，测试次数如下，两种情况
//手机摔坏：测试次数arr[pNum][fNum] = arr[pNum-1][X-1]
//手机完好：测试次数arr[pNum][fNum] = arr[pNum][fNum-X]
//从X层丢手机只是一种方案，题目意思是要求最优方法的最大值，所以在此单独方案下，求测试次数
//实际上是求该方案下的最大值，即：
//Math.max(arr[pNum-1][X-1],arr[pNum][fNum-X])

//从第二个手机开始循环，因为一个手机的时候arr数组里面已经是正确值了
for (int p = 2; p <= pNum; p++)  
{
	//从第二层楼开始循环，因为第一层楼的时候arr数组里面已经是正确值了
	for (int f = 2; f <= fNum; f++) 
	{
		//此循环求一共p个手机，f层楼的测试次数
		//遍历所有方案，即从第1，第2，。。。直到第f层楼开始先扔手机
		for (int i = 1; i <= f; i++) 
		{
			//Java中int类型数组元素默认值为0，所以当i-1或f-i等于0的时候实际上向上和向下是没有次数的，
			//正好和0的值匹配，不影响程序
			int wrong = arr[p-1][i-1] + 1;  //手机摔坏的情况
			int good = arr[p][f-i] + 1;       //手机完好的情况
			//求最优方案的最大测试次数，所以本次方案次数为
			int count = Math.max(wrong, good);
			//由于arr存储的是最优方案，所以把本次方案需要和以前方案比较得到最小值
			arr[p][f] = Math.min(arr[p][f], count);
			//举例循环第一次p=2,f=2,i=1,即求2部手机，2层楼的次数
			//wrong = arr[p-1][i-1] + 1 = arr[1][0] + 1 =0 + 1 = 1
			//good = arr[p][f-i]+1 = arr[2][1] + 1 = 1+1=2
			//count = Math.max(wrong, good) = 2
			//arr[2][2] = Math.min(arr[p][f], count) = Math.min(2, 2) = 2
			//就这样依次循环下去可以将arr数组所有元素全部填满，最后一行，最后一列就是题目要的答案
		}
	}
}
System.out.println(arr[pNum][fNum]);
```

备注：具体图解请点击参看Excel文件 [图解](file/2018_Java_c_10.xlsx)

