using System.Collections.Generic;
public class MetricSelectionModel : ChristoffelElement {
    public ParametersPanelModel parametersPanel;
    public Dictionary<string, string> LaTeXToUnicode = new Dictionary<string, string> {
        [@"\alpha"] = @"α",
        [@"\Alpha"] = @"Α",
        [@"\beta"] = @"β",
        [@"\Beta"] = @"Β",
        [@"\gamma"] = @"γ",
        [@"\Gamma"] = @"Γ",
        [@"\delta"] = @"δ",
        [@"\Delta"] = @"Δ",
        [@"\epsilon"] = @"ϵ",
        [@"\Epsilon"] = @"Ε",
        [@"\zeta"] = @"ζ",
        [@"\Zeta"] = @"Ζ",
        [@"\eta"] = @"η",
        [@"\Eta"] = @"Η",
        [@"\theta"] = @"θ",
        [@"\Theta"] = @"Θ",
        [@"\iota"] = @"ι",
        [@"\Iota"] = @"I",
        [@"\kappa"] = @"κ",
        [@"\Kappa"] = @"Κ",
        [@"\lambda"] = @"λ",
        [@"\Lambda"] = @"Λ",
        [@"\mu"] = @"μ",
        [@"\Mu"] = @"Μ",
        [@"\nu"] = @"ν",
        [@"\Nu"] = @"Ν",
        [@"\xi"] = @"ξ",
        [@"\Xi"] = @"Ξ",
        [@"\omicron"] = @"ο",
        [@"\Omicron"] = @"Ο",
        [@"\pi"] = @"π",
        [@"\Pi"] = @"Π",
        [@"\rho"] = @"ρ",
        [@"\Rho"] = @"Ρ",
        [@"\sigma"] = @"σ",
        [@"\Sigma"] = @"Σ",
        [@"\tau"] = @"τ",
        [@"\Tau"] = @"Τ",
        [@"\upsilon"] = @"υ",
        [@"\Upsilon"] = @"Υ",
        [@"\phi"] = @"ϕ",
        [@"\Phi"] = @"Φ",
        [@"\chi"] = @"χ",
        [@"\Chi"] = @"Χ",
        [@"\psi"] = @"ψ",
        [@"\Psi"] = @"Ψ",
        [@"\omega"] = @"ω",
        [@"\Omega"] = @"Ω",
        [@"\varepsilon"] = @"ε",
        [@"\varkappa"] = @"ϰ",
        [@"\varphi"] = @"φ",
        [@"\varpi"] = @"ϖ",
        [@"\varrho"] = @"ϱ",
        [@"\varsigma"] = @"ς",
        [@"\vartheta"] = @"ϑ",
        [@"\neq"] = @"≠",
        [@"\equiv"] = @"≡",
        [@"\not\equiv"] = @"≢",
        [@"\leq"] = @"≤",
        [@"\geq"] = @"≥",
        [@"\leqq"] = @"≦",
        [@"\geqq"] = @"≧",
        [@"\lneqq"] = @"≨",
        [@"\gneqq"] = @"≩",
        [@"\leqslant"] = @"⩽",
        [@"\geqslant"] = @"⩾",
        [@"\ll"] = @"≪",
        [@"\gg"] = @"≫",
        [@"\nless"] = @"≮",
        [@"\ngtr"] = @"≯",
        [@"\nleq"] = @"≰",
        [@"\ngeq"] = @"≱",
        [@"\lessequivlnt"] = @"≲",
        [@"\greaterequivlnt"] = @"≳",
        [@"\prec"] = @"≺",
        [@"\succ"] = @"≻",
        [@"\preccurlyeq"] = @"≼",
        [@"\succcurlyeq"] = @"≽",
        [@"\precapprox"] = @"≾",
        [@"\succapprox"] = @"≿",
        [@"\nprec"] = @"⊀",
        [@"\nsucc"] = @"⊁",
        [@"\sim"] = @"∼",
        [@"\not\sim"] = @"≁",
        [@"\simeq"] = @"≃",
        [@"\not\simeq"] = @"≄",
        [@"\backsim"] = @"∽",
        [@"\lazysinv"] = @"∾",
        [@"\wr"] = @"≀",
        [@"\cong"] = @"≅",
        [@"\not\cong"] = @"≇",
        [@"\approx"] = @"≈",
        [@"\not\approx"] = @"≉",
        [@"\approxeq"] = @"≊",
        [@"\approxnotequal"] = @"≆",
        [@"\tildetrpl"] = @"≋",
        [@"\allequal"] = @"≌",
        [@"\asymp"] = @"≍",
        [@"\doteq"] = @"≐",
        [@"\doteqdot"] = @"≑",
        [@"\lneq"] = @"⪇",
        [@"\gneq"] = @"⪈",
        [@"\preceq"] = @"⪯",
        [@"\succeq"] = @"⪰",
        [@"\precneqq"] = @"⪵",
        [@"\succneqq"] = @"⪶",
        [@"#Sets and"] = @"Logic",
        [@"\emptyset"] = @"∅",
        [@"\in"] = @"∈",
        [@"\notin	∉"] = @"",
        [@"\not\in"] = @"∉",
        [@"\ni"] = @"∋",
        [@"\not\ni"] = @"∌",
        [@"\subset"] = @"⊂",
        [@"\subseteq"] = @"⊆",
        [@"\not\subset"] = @"⊄",
        [@"\not\subseteq"] = @"⊈",
        [@"\supset"] = @"⊃",
        [@"\supseteq"] = @"⊇",
        [@"\not\supset"] = @"⊅",
        [@"\not\supseteq"] = @"⊉",
        [@"\subsetneq"] = @"⊊",
        [@"\supsetneq"] = @"⊋",
        [@"\exists"] = @"∃",
        [@"\nexists	∄"] = @"",
        [@"\not\exists"] = @"∄",
        [@"\forall"] = @"∀",
        [@"\aleph"] = @"ℵ",
        [@"\beth"] = @"ℶ",
        [@"\neg"] = @"¬",
        [@"\wedge"] = @"∧",
        [@"\vee"] = @"∨",
        [@"\veebar"] = @"⊻",
        [@"\land"] = @"∧",
        [@"\lor"] = @"∨",
        [@"\top"] = @"⊤",
        [@"\bot"] = @"⊥",
        [@"\cup"] = @"∪",
        [@"\cap"] = @"∩",
        [@"\bigcup"] = @"⋃",
        [@"\bigcap"] = @"⋂",
        [@"\setminus"] = @"∖",
        [@"\therefore"] = @"∴",
        [@"\because"] = @"∵",
        [@"\Box"] = @"□",
        [@"\models"] = @"⊨",
        [@"\vdash"] = @"⊢",
        [@"\rightarrow	→"] = @"",
        [@"\Rightarrow"] = @"⇒",
        [@"\leftarrow	←"] = @"",
        [@"\Leftarrow"] = @"⇐",
        [@"\uparrow	↑"] = @"",
        [@"\Uparrow"] = @"⇑",
        [@"\downarrow	↓"] = @"",
        [@"\Downarrow"] = @"⇓",
        [@"\nwarrow	↖"] = @"",
        [@"\nearrow"] = @"↗",
        [@"\searrow	↘"] = @"",
        [@"\swarrow"] = @"↙",
        [@"\mapsto"] = @"↦",
        [@"\to"] = @"→",
        [@"\leftrightarrow	↔"] = @"",
        [@"\hookleftarrow"] = @"↩",
        [@"\Leftrightarrow"] = @"⇔",
        [@"\rightarrowtail	↣"] = @"",
        [@"\leftarrowtail"] = @"↢",
        [@"\twoheadrightarrow	↠"] = @"",
        [@"\twoheadleftarrow"] = @"↞",
        [@"\hookrightarrow	↪"] = @"",
        [@"\hookleftarrow"] = @"↩",
        [@"\rightsquigarrow"] = @"⇝",
        [@"\rightleftharpoons	⇌"] = @"",
        [@"\leftrightharpoons"] = @"⇋",
        [@"\rightharpoonup	⇀"] = @"",
        [@"\rightharpoondown"] = @"⇁",
        [@"\times"] = @"×",
        [@"\div"] = @"÷",
        [@"\infty"] = @"∞",
        [@"\nabla"] = @"∇",
        [@"\partial"] = @"∂",
        [@"\sum"] = @"∑",
        [@"\prod"] = @"∏",
        [@"\coprod"] = @"∐",
        [@"\int"] = @"∫",
        [@"\iint"] = @"∬",
        [@"\iiint"] = @"∭",
        [@"\iiiint"] = @"⨌",
        [@"\oint"] = @"∮",
        [@"\surfintegral"] = @"∯",
        [@"\volintegral"] = @"∰",
        [@"\Re"] = @"ℜ",
        [@"\Im"] = @"ℑ",
        [@"\wp"] = @"℘",
        [@"\mp"] = @"∓",
        [@"\langle"] = @"⟨",
        [@"\rangle"] = @"⟩",
        [@"\lfloor"] = @"⌊",
        [@"\rfloor"] = @"⌋",
        [@"\lceil"] = @"⌈",
        [@"\rceil"] = @"⌉",
        [@"\mathbb{a}"] = @"𝕒",
        [@"\mathbb{A}"] = @"𝔸",
        [@"\mathbb{b}"] = @"𝕓",
        [@"\mathbb{B}"] = @"𝔹",
        [@"\mathbb{c}"] = @"𝕔",
        [@"\mathbb{C}"] = @"ℂ",
        [@"\mathbb{d}"] = @"𝕕",
        [@"\mathbb{D}"] = @"𝔻",
        [@"\mathbb{e}"] = @"𝕖",
        [@"\mathbb{E}"] = @"𝔼",
        [@"\mathbb{f}"] = @"𝕗",
        [@"\mathbb{F}"] = @"𝔽",
        [@"\mathbb{g}"] = @"𝕘",
        [@"\mathbb{G}"] = @"𝔾",
        [@"\mathbb{h}"] = @"𝕙",
        [@"\mathbb{H}"] = @"ℍ",
        [@"\mathbb{i}"] = @"𝕚",
        [@"\mathbb{I}"] = @"𝕀",
        [@"\mathbb{j}"] = @"𝕛",
        [@"\mathbb{J}"] = @"𝕁",
        [@"\mathbb{k}"] = @"𝕜",
        [@"\mathbb{K}"] = @"𝕂",
        [@"\mathbb{l}"] = @"𝕝",
        [@"\mathbb{L}"] = @"𝕃",
        [@"\mathbb{m}"] = @"𝕞",
        [@"\mathbb{M}"] = @"𝕄",
        [@"\mathbb{n}"] = @"𝕟",
        [@"\mathbb{N}"] = @"ℕ",
        [@"\mathbb{o}"] = @"𝕠",
        [@"\mathbb{O}"] = @"𝕆",
        [@"\mathbb{p}"] = @"𝕡",
        [@"\mathbb{P}"] = @"ℙ",
        [@"\mathbb{q}"] = @"𝕢",
        [@"\mathbb{Q}"] = @"ℚ",
        [@"\mathbb{r}"] = @"𝕣",
        [@"\mathbb{R}"] = @"ℝ",
        [@"\mathbb{s}"] = @"𝕤",
        [@"\mathbb{S}"] = @"𝕊",
        [@"\mathbb{t}"] = @"𝕥",
        [@"\mathbb{T}"] = @"𝕋",
        [@"\mathbb{u}"] = @"𝕦",
        [@"\mathbb{U}"] = @"𝕌",
        [@"\mathbb{v}"] = @"𝕧",
        [@"\mathbb{V}"] = @"𝕍",
        [@"\mathbb{x}"] = @"𝕩",
        [@"\mathbb{X}"] = @"𝕏",
        [@"\mathbb{y}"] = @"𝕪",
        [@"\mathbb{Y}"] = @"𝕐",
        [@"\mathbb{z}"] = @"𝕫",
        [@"\mathbb{Z}"] = @"ℤ",
        [@"\mathbb{0}"] = @"𝟘",
        [@"\mathbb{1}"] = @"𝟙",
        [@"\mathbb{2}"] = @"𝟚",
        [@"\mathbb{3}"] = @"𝟛",
        [@"\mathbb{4}"] = @"𝟜",
        [@"\mathbb{5}"] = @"𝟝",
        [@"\mathbb{6}"] = @"𝟞",
        [@"\mathbb{7}"] = @"𝟟",
        [@"\mathbb{8}"] = @"𝟠",
        [@"\mathbb{9}"] = @"𝟡",
        [@"\mathfrak{a}"] = @"𝔞",
        [@"\mathfrak{A}"] = @"𝔄",
        [@"\mathfrak{b}"] = @"𝔟",
        [@"\mathfrak{B}"] = @"𝔅",
        [@"\mathfrak{c}"] = @"𝔠",
        [@"\mathfrak{C}"] = @"ℭ",
        [@"\mathfrak{d}"] = @"𝔡",
        [@"\mathfrak{D}"] = @"𝔇",
        [@"\mathfrak{e}"] = @"𝔢",
        [@"\mathfrak{E}"] = @"𝔈",
        [@"\mathfrak{f}"] = @"𝔣",
        [@"\mathfrak{F}"] = @"𝔉",
        [@"\mathfrak{g}"] = @"𝔤",
        [@"\mathfrak{G}"] = @"𝔊",
        [@"\mathfrak{h}"] = @"𝔥",
        [@"\mathfrak{H}"] = @"ℌ",
        [@"\mathfrak{i}"] = @"𝔦",
        [@"\mathfrak{I}"] = @"ℑ",
        [@"\mathfrak{j}"] = @"𝔧",
        [@"\mathfrak{J}"] = @"𝔍",
        [@"\mathfrak{k}"] = @"𝔨",
        [@"\mathfrak{K}"] = @"𝔎",
        [@"\mathfrak{l}"] = @"𝔩",
        [@"\mathfrak{L}"] = @"𝔏",
        [@"\mathfrak{m}"] = @"𝔪",
        [@"\mathfrak{M}"] = @"𝔐",
        [@"\mathfrak{n}"] = @"𝔫",
        [@"\mathfrak{N}"] = @"𝔑",
        [@"\mathfrak{o}"] = @"𝔬",
        [@"\mathfrak{O}"] = @"𝔒",
        [@"\mathfrak{p}"] = @"𝔭",
        [@"\mathfrak{P}"] = @"𝔓",
        [@"\mathfrak{q}"] = @"𝔮",
        [@"\mathfrak{Q}"] = @"𝔔",
        [@"\mathfrak{r}"] = @"𝔯",
        [@"\mathfrak{R}"] = @"ℜ",
        [@"\mathfrak{s}"] = @"𝔰",
        [@"\mathfrak{S}"] = @"𝔖",
        [@"\mathfrak{t}"] = @"𝔱",
        [@"\mathfrak{T}"] = @"𝔗",
        [@"\mathfrak{u}"] = @"𝔲",
        [@"\mathfrak{U}"] = @"𝔘",
        [@"\mathfrak{v}"] = @"𝔳",
        [@"\mathfrak{V}"] = @"𝔙",
        [@"\mathfrak{x}"] = @"𝔵",
        [@"\mathfrak{X}"] = @"𝔛",
        [@"\mathfrak{y}"] = @"𝔶",
        [@"\mathfrak{Y}"] = @"𝔜",
        [@"\mathfrak{z}"] = @"𝔷",
        [@"\mathfrak{Z}"] = @"ℨ",
        [@"_0"] = @"₀",
        [@"^0"] = @"⁰",
        [@"_1"] = @"₁",
        [@"^1"] = @"¹",
        [@"_2"] = @"₂",
        [@"^2"] = @"²",
        [@"_3"] = @"₃",
        [@"^3"] = @"³",
        [@"_4"] = @"₄",
        [@"^4"] = @"⁴",
        [@"_5"] = @"₅",
        [@"^5"] = @"⁵",
        [@"_6"] = @"₆",
        [@"^6"] = @"⁶",
        [@"_7"] = @"₇",
        [@"^7"] = @"⁷",
        [@"_8"] = @"₈",
        [@"^8"] = @"⁸",
        [@"_9"] = @"₉",
        [@"^9"] = @"⁹",
        [@"_+"] = @"₊",
        [@"^+"] = @"⁺",
        [@"_-"] = @"₋",
        [@"^-"] = @"⁻",
        [@"_("] = @"₍",
        [@"^("] = @"⁽",
        [@"_)"] = @"₎",
        [@"^)"] = @"⁾",
        [@"_a"] = @"ₐ",
        [@"^a"] = @"ᵃ",
        [@"^b"] = @"ᵇ",
        [@"^c"] = @"ᶜ",
        [@"^d"] = @"ᵈ",
        [@"_e"] = @"ₑ",
        [@"^e"] = @"ᵉ",
        [@"^f"] = @"ᶠ",
        [@"^g"] = @"ᵍ",
        [@"_h"] = @"ₕ",
        [@"^h"] = @"ʰ",
        [@"_i"] = @"ᵢ",
        [@"^i"] = @"ⁱ",
        [@"_j"] = @"ⱼ",
        [@"^j"] = @"ʲ",
        [@"_k"] = @"ₖ",
        [@"^k"] = @"ᵏ",
        [@"_l"] = @"ₗ",
        [@"^l"] = @"ˡ",
        [@"_m"] = @"ₘ",
        [@"^m"] = @"ᵐ",
        [@"_n"] = @"ₙ",
        [@"^n"] = @"ⁿ",
        [@"_o"] = @"ₒ",
        [@"^o"] = @"ᵒ",
        [@"_p"] = @"ₚ",
        [@"^p"] = @"ᵖ",
        [@"_r"] = @"ᵣ",
        [@"^r"] = @"ʳ",
        [@"_s"] = @"ₛ",
        [@"^s"] = @"ˢ",
        [@"_t"] = @"ₜ",
        [@"^t"] = @"ᵗ",
        [@"_u"] = @"ᵤ",
        [@"^u"] = @"ᵘ",
        [@"_v"] = @"ᵥ",
        [@"^v"] = @"ᵛ",
        [@"^w"] = @"ʷ",
        [@"_x"] = @"ₓ",
        [@"^x"] = @"ˣ",
        [@"^y"] = @"ʸ",
        [@"^z"] = @"ᶻ",
        [@"\mp"] = @"∓",
        [@"\dotplus"] = @"∔",
        [@"\bullet"] = @"∙",
        [@"\cdot"] = @"⋅",
        [@"\oplus"] = @"⊕",
        [@"\ominus"] = @"⊖",
        [@"\otimes"] = @"⊗",
        [@"\oslash"] = @"⊘",
        [@"\odot"] = @"⊙",
        [@"\circ"] = @"∘",
        [@"\surd"] = @"√",
        [@"\propto"] = @"∝",
        [@"\angle"] = @"∠",
        [@"\measuredangle"] = @"∡",
        [@"\sphericalangle"] = @"∢",
        [@"\mid"] = @"∣",
        [@"\nmid	"] = @"∤",
        [@"\not\mid"] = @"∤",
        [@"\parallel"] = @"∥",
        [@"\nparallel	"] = @"∦",
        [@"\not\parallel"] = @"∦",
        [@"\flat"] = @"♭",
        [@"\natural"] = @"♮",
        [@"\sharp"] = @"♯",
        ["a"] = "a",
        ["b"] = "b",
        ["c"] = "c",
        ["d"] = "d",
        ["e"] = "e",
        ["f"] = "f",
        ["g"] = "g",
        ["h"] = "h",
        ["i"] = "i",
        ["j"] = "j",
        ["k"] = "k",
        ["l"] = "l",
        ["m"] = "m",
        ["n"] = "n",
        ["o"] = "o",
        ["p"] = "p",
        ["q"] = "q",
        ["r"] = "r",
        ["s"] = "s",
        ["t"] = "t",
        ["u"] = "u",
        ["v"] = "v",
        ["w"] = "w",
        ["x"] = "x",
        ["y"] = "y",
        ["z"] = "z",
        ["A"] = "A",
        ["B"] = "B",
        ["C"] = "C",
        ["D"] = "D",
        ["E"] = "E",
        ["F"] = "F",
        ["G"] = "G",
        ["H"] = "H",
        ["I"] = "I",
        ["J"] = "J",
        ["K"] = "K",
        ["L"] = "L",
        ["M"] = "M",
        ["N"] = "N",
        ["O"] = "O",
        ["P"] = "P",
        ["Q"] = "Q",
        ["R"] = "R",
        ["S"] = "S",
        ["T"] = "T",
        ["U"] = "U",
        ["V"] = "V",
        ["W"] = "W",
        ["X"] = "X",
        ["Y"] = "Y",
        ["Z"] = "Z",
        ["\\textfractionsolidus"] = "\u2044",
        [@"\leftrightsquigarrow"] = "\u21AD",
        [@"\textpertenthousand"] = "\u2031",
        [@"\blacktriangleright"] = "\u25B8",
        [@"\blacktriangledown"] = "\u25BE",
        [@"\blacktriangleleft"] = "\u25C2",
        [@"\twoheadrightarrow"] = "\u21A0",
        [@"\leftrightharpoons"] = "\u21CB",
        [@"\rightleftharpoons"] = "\u21CC",
        [@"\textreferencemark"] = "\u203B",
        [@"\circlearrowright"] = "\u21BB",
        [@"\rightrightarrows"] = "\u21C9",
        [@"\vartriangleright"] = "\u22B3",
        [@"\textordmasculine"] = "\u00BA",
        [@"\textvisiblespace"] = "\u2423",
        [@"\twoheadleftarrow"] = "\u219E",
        [@"\downharpoonright"] = "\u21C2",
        [@"\ntrianglerighteq"] = "\u22ED",
        [@"\rightharpoondown"] = "\u21C1",
        [@"\textperthousand"] = "\u2030",
        [@"\leftrightarrows"] = "\u21C6",
        [@"\textmusicalnote"] = "\u266A",
        [@"\nleftrightarrow"] = "\u21AE",
        [@"\rightleftarrows"] = "\u21C4",
        [@"\bigtriangledown"] = "\u25BD",
        [@"\textordfeminine"] = "\u00AA",
        [@"\ntrianglelefteq"] = "\u22EC",
        [@"\rightthreetimes"] = "\u22CC",
        [@"\trianglerighteq"] = "\u22B5",
        [@"\vartriangleleft"] = "\u22B2",
        [@"\rightsquigarrow"] = "\u21DD",
        [@"\downharpoonleft"] = "\u21C3",
        [@"\curvearrowright"] = "\u21B7",
        [@"\circlearrowleft"] = "\u21BA",
        [@"\leftharpoondown"] = "\u21BD",
        [@"\nLeftrightarrow"] = "\u21CE",
        [@"\curvearrowleft"] = "\u21B6",
        [@"\guilsinglright"] = "\u203A",
        [@"\leftthreetimes"] = "\u22CB",
        [@"\leftrightarrow"] = "\u2194",
        [@"\rightharpoonup"] = "\u21C0",
        [@"\guillemotright"] = "\u00BB",
        [@"\downdownarrows"] = "\u21CA",
        [@"\hookrightarrow"] = "\u21AA",
        [@"\hspace{0.25em}"] = "\u2005",
        [@"\dashrightarrow"] = "\u21E2",
        [@"\leftleftarrows"] = "\u21C7",
        [@"\trianglelefteq"] = "\u22B4",
        [@"\ntriangleright"] = "\u22EB",
        [@"\doublebarwedge"] = "\u2306",
        [@"\upharpoonright"] = "\u21BE",
        [@"\rightarrowtail"] = "\u21A3",
        [@"\looparrowright"] = "\u21AC",
        [@"\Leftrightarrow"] = "\u21D4",
        [@"\sphericalangle"] = "\u2222",
        [@"\divideontimes"] = "\u22C7",
        [@"\measuredangle"] = "\u2221",
        [@"\blacktriangle"] = "\u25B4",
        [@"\ntriangleleft"] = "\u22EA",
        [@"\mathchar""1356"] = "\u2041",
        [@"\texttrademark"] = "\u2122",
        [@"\mathchar""2208"] = "\u2316",
        [@"\triangleright"] = "\u25B9",
        [@"\leftarrowtail"] = "\u21A2",
        [@"\guilsinglleft"] = "\u2039",
        [@"\upharpoonleft"] = "\u21BF",
        [@"\mathbb{gamma}"] = "\u213D",
        [@"\fallingdotseq"] = "\u2252",
        [@"\looparrowleft"] = "\u21AB",
        [@"\textbrokenbar"] = "\u00A6",
        [@"\hookleftarrow"] = "\u21A9",
        [@"\smallsetminus"] = "\uFE68",
        [@"\dashleftarrow"] = "\u21E0",
        [@"\guillemotleft"] = "\u00AB",
        [@"\leftharpoonup"] = "\u21BC",
        [@"\mathbb{Gamma}"] = "\u213E",
        [@"\bigtriangleup"] = "\u25B3",
        [@"\textcircledP"] = "\u2117",
        [@"\risingdotseq"] = "\u2253",
        [@"\triangleleft"] = "\u25C3",
        [@"\mathsterling"] = "\u00A3",
        [@"\textcurrency"] = "\u00A4",
        [@"\triangledown"] = "\u25BF",
        [@"\blacklozenge"] = "\uE80B",
        [@"\sfrac{5}{6}"] = "\u215A",
        [@"\preccurlyeq"] = "\u227C",
        [@"\Rrightarrow"] = "\u21DB",
        [@"\circledcirc"] = "\u229A",
        [@"\nRightarrow"] = "\u21CF",
        [@"\sfrac{3}{8}"] = "\u215C",
        [@"\sfrac{1}{3}"] = "\u2153",
        [@"\sfrac{2}{5}"] = "\u2156",
        [@"\vartriangle"] = "\u25B5",
        [@"\Updownarrow"] = "\u21D5",
        [@"\nrightarrow"] = "\u219B",
        [@"\sfrac{1}{2}"] = "\u00BD",
        [@"\sfrac{3}{5}"] = "\u2157",
        [@"\succcurlyeq"] = "\u227D",
        [@"\sfrac{4}{5}"] = "\u2158",
        [@"\diamondsuit"] = "\u2666",
        [@"\hphantom{0}"] = "\u2007",
        [@"\sfrac{1}{6}"] = "\u2159",
        [@"\curlyeqsucc"] = "\u22DF",
        [@"\blacksquare"] = "\u25AA",
        [@"\hphantom{,}"] = "\u2008",
        [@"\curlyeqprec"] = "\u22DE",
        [@"\sfrac{1}{8}"] = "\u215B",
        [@"\sfrac{7}{8}"] = "\u215E",
        [@"\sfrac{1}{5}"] = "\u2155",
        [@"\sfrac{2}{3}"] = "\u2154",
        [@"\updownarrow"] = "\u2195",
        [@"\backepsilon"] = "\u220D",
        [@"\circleddash"] = "\u229D",
        [@"\eqslantless"] = "\u22DC",
        [@"\sfrac{3}{4}"] = "\u00BE",
        [@"\sfrac{5}{8}"] = "\u215D",
        [@"\hspace{1pt}"] = "\u200A",
        [@"\sfrac{1}{4}"] = "\u00BC",
        [@"\mathbb{Pi}"] = "\u213F",
        [@"\mathcal{M}"] = "\u2133",
        [@"\nsupseteqq"] = "\u2289",
        [@"\mathcal{B}"] = "\u212C",
        [@"\textrecipe"] = "\u211E",
        [@"\nsubseteqq"] = "\u2288",
        [@"\subsetneqq"] = "\u228A",
        [@"\mathcal{I}"] = "\u2111",
        [@"\upuparrows"] = "\u21C8",
        [@"\mathcal{e}"] = "\u212F",
        [@"\mathcal{L}"] = "\u2112",
        [@"\nleftarrow"] = "\u219A",
        [@"\mathcal{H}"] = "\u210B",
        [@"\mathcal{E}"] = "\u2130",
        [@"\eqslantgtr"] = "\u22DD",
        [@"\curlywedge"] = "\u22CF",
        [@"\varepsilon"] = "\u03B5",
        [@"\supsetneqq"] = "\u228B",
        [@"\rightarrow"] = "\u2192",
        [@"\mathcal{R}"] = "\u211B",
        [@"\sqsubseteq"] = "\u2291",
        [@"\mathcal{g}"] = "\u210A",
        [@"\sqsupseteq"] = "\u2292",
        [@"\complement"] = "\u2201",
        [@"\Rightarrow"] = "\u21D2",
        [@"\gtreqqless"] = "\u22DB",
        [@"\lesseqqgtr"] = "\u22DA",
        [@"\circledast"] = "\u229B",
        [@"\nLeftarrow"] = "\u21CD",
        [@"\Lleftarrow"] = "\u21DA",
        [@"\Leftarrow"] = "\u21D0",
        [@"\gvertneqq"] = "\u2269",
        [@"\mathbb{C}"] = "\u2102",
        [@"\supsetneq"] = "\u228B",
        [@"\leftarrow"] = "\u2190",
        [@"\nleqslant"] = "\u2270",
        [@"\mathbb{Q}"] = "\u211A",
        [@"\mathbb{Z}"] = "\u2124",
        [@"\llbracket"] = "\u301A",
        [@"\mathbb{H}"] = "\u210D",
        [@"\spadesuit"] = "\u2660",
        [@"\mathit{o}"] = "\u2134",
        [@"\mathbb{P}"] = "\u2119",
        [@"\rrbracket"] = "\u301B",
        [@"\supseteqq"] = "\u2287",
        [@"\copyright"] = "\u00A9",
        [@"\textsc{k}"] = "\u0138",
        [@"\gtreqless"] = "\u22DB",
        [@"\mathbb{j}"] = "\u2149",
        [@"\pitchfork"] = "\u22D4",
        [@"\estimated"] = "\u212E",
        [@"\ngeqslant"] = "\u2271",
        [@"\mathbb{e}"] = "\u2147",
        [@"\therefore"] = "\u2234",
        [@"\triangleq"] = "\u225C",
        [@"\varpropto"] = "\u221D",
        [@"\subsetneq"] = "\u228A",
        [@"\heartsuit"] = "\u2665",
        [@"\mathbb{d}"] = "\u2146",
        [@"\lvertneqq"] = "\u2268",
        [@"\checkmark"] = "\u2713",
        [@"\nparallel"] = "\u2226",
        [@"\mathbb{R}"] = "\u211D",
        [@"\lesseqgtr"] = "\u22DA",
        [@"\downarrow"] = "\u2193",
        [@"\mathbb{D}"] = "\u2145",
        [@"\mathbb{i}"] = "\u2148",
        [@"\backsimeq"] = "\u22CD",
        [@"\mathbb{N}"] = "\u2115",
        [@"\Downarrow"] = "\u21D3",
        [@"\subseteqq"] = "\u2286",
        [@"\setminus"] = "\u2216",
        [@"\succnsim"] = "\u22E9",
        [@"\doteqdot"] = "\u2251",
        [@"\clubsuit"] = "\u2663",
        [@"\emptyset"] = "\u2205",
        [@"\varnothing"] = "\u2205",
        [@"\sqsupset"] = "\u2290",
        [@"\fbox{~~}"] = "\u25AD",
        [@"\curlyvee"] = "\u22CE",
        [@"\varkappa"] = "\u03F0",
        [@"\llcorner"] = "\u231E",
        [@"\varsigma"] = "\u03C2",
        [@"\approxeq"] = "\u224A",
        [@"\backcong"] = "\u224C",
        [@"\supseteq"] = "\u2287",
        [@"\circledS"] = "\u24C8",
        [@"\circledR"] = "\u00AE",
        [@"\textcent"] = "\u00A2",
        [@"\urcorner"] = "\u231D",
        [@"\lrcorner"] = "\u231F",
        [@"\boxminus"] = "\u229F",
        [@"\texteuro"] = "\u20AC",
        [@"\vartheta"] = "\u03D1",
        [@"\barwedge"] = "\u22BC",
        [@"\ding{86}"] = "\u2736",
        [@"\sqsubset"] = "\u228F",
        [@"\subseteq"] = "\u2286",
        [@"\intercal"] = "\u22BA",
        [@"\ding{73}"] = "\u2606",
        [@"\ulcorner"] = "\u231C",
        [@"\recorder"] = "\u2315",
        [@"\precnsim"] = "\u22E8",
        [@"\parallel"] = "\u2225",
        [@"\boxtimes"] = "\u22A0",
        [@"\ding{55}"] = "\u2717",
        [@"\multimap"] = "\u22B8",
        [@"\maltese"] = "\u2720",
        [@"\nearrow"] = "\u2197",
        [@"\swarrow"] = "\u2199",
        [@"\lozenge"] = "\u25CA",
        [@"\sqrt[3]"] = "\u221B",
        [@"\succsim"] = "\u227F",
        [@"\tilde{}"] = "\u007E",
        [@"\lessgtr"] = "\u2276",
        [@"\Upsilon"] = "\u03D2",
        [@"\Cdprime"] = "\u042A",
        [@"\gtrless"] = "\u2277",
        [@"\backsim"] = "\u223D",
        [@"\nexists"] = "\u2204",
        [@"\dotplus"] = "\u2214",
        [@"\searrow"] = "\u2198",
        [@"\lessdot"] = "\u22D6",
        [@"\boxplus"] = "\u229E",
        [@"\upsilon"] = "\u03C5",
        [@"\epsilon"] = "\u03B5",
        [@"\diamond"] = "\u22C4",
        [@"\bigstar"] = "\u2605",
        [@"\ddagger"] = "\u2021",
        [@"\cdprime"] = "\u044A",
        [@"\Uparrow"] = "\u21D1",
        [@"\sqrt[4]"] = "\u221C",
        [@"\between"] = "\u226C",
        [@"\sqangle"] = "\u221F",
        [@"\digamma"] = "\u03DC",
        [@"\uparrow"] = "\u2191",
        [@"\nwarrow"] = "\u2196",
        [@"\precsim"] = "\u227E",
        [@"\breve{}"] = "\u02D8",
        [@"\because"] = "\u2235",
        [@"\bigcirc"] = "\u25EF",
        [@"\acute{}"] = "\u00B4",
        [@"\grave{}"] = "\u0060",
        [@"\check{}"] = "\u02C7",
        [@"\lesssim"] = "\u2272",
        [@"\partial"] = "\u2202",
        [@"\natural"] = "\u266E",
        [@"\supset"] = "\u2283",
        [@"\hstrok"] = "\u0127",
        [@"\Tstrok"] = "\u0166",
        [@"\coprod"] = "\u2210",
        [@"\models"] = "\u22A7",
        [@"\otimes"] = "\u2297",
        [@"\degree"] = "\u00B0",
        [@"\gtrdot"] = "\u22D7",
        [@"\preceq"] = "\u227C",
        [@"\Lambda"] = "\u039B",
        [@"\lambda"] = "\u03BB",
        [@"\cprime"] = "\u044C",
        [@"\varrho"] = "\u03F1",
        [@"\Bumpeq"] = "\u224E",
        [@"\hybull"] = "\u2043",
        [@"\lmidot"] = "\u0140",
        [@"\nvdash"] = "\u22AC",
        [@"\lbrace"] = "\u007B",
        [@"\bullet"] = "\u2022",
        [@"\varphi"] = "\u03D5",
        [@"\bumpeq"] = "\u224F",
        [@"\ddot{}"] = "\u00A8",
        [@"\Lmidot"] = "\u013F",
        [@"\Cprime"] = "\u042C",
        [@"\female"] = "\u2640",
        [@"\rtimes"] = "\u22CA",
        [@"\gtrsim"] = "\u2273",
        [@"\mapsto"] = "\u21A6",
        [@"\daleth"] = "\u2138",
        [@"\square"] = "\u25A0",
        [@"\nVDash"] = "\u22AF",
        [@"\rangle"] = "\u3009",
        [@"\tstrok"] = "\u0167",
        [@"\oslash"] = "\u2298",
        [@"\ltimes"] = "\u22C9",
        [@"\lfloor"] = "\u230A",
        [@"\marker"] = "\u25AE",
        [@"\Subset"] = "\u22D0",
        [@"\Vvdash"] = "\u22AA",
        [@"\propto"] = "\u221D",
        [@"\Hstrok"] = "\u0126",
        [@"\dlcrop"] = "\u230D",
        [@"\forall"] = "\u2200",
        [@"\nVdash"] = "\u22AE",
        [@"\Supset"] = "\u22D1",
        [@"\langle"] = "\u3008",
        [@"\ominus"] = "\u2296",
        [@"\rfloor"] = "\u230B",
        [@"\circeq"] = "\u2257",
        [@"\eqcirc"] = "\u2256",
        [@"\drcrop"] = "\u230C",
        [@"\veebar"] = "\u22BB",
        [@"\ulcrop"] = "\u230F",
        [@"\nvDash"] = "\u22AD",
        [@"\urcrop"] = "\u230E",
        [@"\exists"] = "\u2203",
        [@"\approx"] = "\u2248",
        [@"\dagger"] = "\u2020",
        [@"\boxdot"] = "\u22A1",
        [@"\succeq"] = "\u227D",
        [@"\bowtie"] = "\u22C8",
        [@"\subset"] = "\u2282",
        [@"\Sigma"] = "\u03A3",
        [@"\Omega"] = "\u03A9",
        [@"\nabla"] = "\u2207",
        [@"\colon"] = "\u003A",
        [@"\boxHu"] = "\u2567",
        [@"\boxHd"] = "\u2564",
        [@"\aleph"] = "\u2135",
        [@"\gnsim"] = "\u22E7",
        [@"\boxHU"] = "\u2569",
        [@"\boxHD"] = "\u2566",
        [@"\equiv"] = "\u2261",
        [@"\lneqq"] = "\u2268",
        [@"\amalg"] = "\u2210",
        [@"\boxhU"] = "\u2568",
        [@"\boxhD"] = "\u2565",
        [@"\uplus"] = "\u228E",
        [@"\boxhu"] = "\u2534",
        [@"\kappa"] = "\u03BA",
        [@"\sigma"] = "\u03C3",
        [@"\boxDL"] = "\u2557",
        [@"\Theta"] = "\u0398",
        [@"\Vdash"] = "\u22A9",
        [@"\boxDR"] = "\u2554",
        [@"\boxDl"] = "\u2556",
        [@"\sqcap"] = "\u2293",
        [@"\boxDr"] = "\u2553",
        [@"\bar{}"] = "\u00AF",
        [@"\dashv"] = "\u22A3",
        [@"\vDash"] = "\u22A8",
        [@"\boxdl"] = "\u2510",
        [@"\boxVl"] = "\u2562",
        [@"\boxVh"] = "\u256B",
        [@"\boxVr"] = "\u255F",
        [@"\boxdr"] = "\u250C",
        [@"\boxdL"] = "\u2555",
        [@"\boxVL"] = "\u2563",
        [@"\boxVH"] = "\u256C",
        [@"\boxVR"] = "\u2560",
        [@"\boxdR"] = "\u2552",
        [@"\theta"] = "\u03B8",
        [@"\lhblk"] = "\u2584",
        [@"\uhblk"] = "\u2580",
        [@"\ldotp"] = "\u002E",
        [@"\ldots"] = "\u2026",
        [@"\boxvL"] = "\u2561",
        [@"\boxvH"] = "\u256A",
        [@"\boxvR"] = "\u255E",
        [@"\boxvl"] = "\u2524",
        [@"\boxvh"] = "\u253C",
        [@"\boxvr"] = "\u251C",
        [@"\Delta"] = "\u0394",
        [@"\boxUR"] = "\u255A",
        [@"\boxUL"] = "\u255D",
        [@"\oplus"] = "\u2295",
        [@"\boxUr"] = "\u2559",
        [@"\boxUl"] = "\u255C",
        [@"\doteq"] = "\u2250",
        [@"\happy"] = "\u32E1",
        [@"\varpi"] = "\u03D6",
        [@"\boxur"] = "\u2514",
        [@"\smile"] = "\u263A",
        [@"\boxul"] = "\u2518",
        [@"\simeq"] = "\u2243",
        [@"\boxuR"] = "\u2558",
        [@"\boxuL"] = "\u255B",
        [@"\boxhd"] = "\u252C",
        [@"\gimel"] = "\u2137",
        [@"\Gamma"] = "\u0393",
        [@"\lnsim"] = "\u22E6",
        [@"\sqcup"] = "\u2294",
        [@"\omega"] = "\u03C9",
        [@"\sharp"] = "\u266F",
        [@"\times"] = "\u00D7",
        [@"\block"] = "\u2588",
        [@"\hat{}"] = "\u005E",
        [@"\wedge"] = "\u2227",
        [@"\vdash"] = "\u22A2",
        [@"\angle"] = "\u2220",
        [@"\infty"] = "\u221E",
        [@"\gamma"] = "\u03B3",
        [@"\asymp"] = "\u224D",
        [@"\rceil"] = "\u2309",
        [@"\dot{}"] = "\u02D9",
        [@"\lceil"] = "\u2308",
        [@"\delta"] = "\u03B4",
        [@"\gneqq"] = "\u2269",
        [@"\frown"] = "\u2322",
        [@"\phone"] = "\u260E",
        [@"\vdots"] = "\u22EE",
        [@"\k{i}"] = "\u012F",
        [@"\`{I}"] = "\u00CC",
        [@"\perp"] = "\u22A5",
        [@"\""{o}"] = "\u00F6",
        [@"\={I}"] = "\u012A",
        [@"\`{a}"] = "\u00E0",
        [@"\v{T}"] = "\u0164",
        [@"\surd"] = "\u221A",
        [@"\H{O}"] = "\u0150",
        [@"\vert"] = "\u007C",
        [@"\k{I}"] = "\u012E",
        [@"\""{y}"] = "\u00FF",
        [@"\""{O}"] = "\u00D6",
        [@"\""{Y}"] = "\u00DD",
        [@"\u{u}"] = "\u045E",
        [@"\u{G}"] = "\u011E",
        [@"\.{E}"] = "\u0116",
        [@"\.{z}"] = "\u017C",
        [@"\v{t}"] = "\u0165",
        [@"\prec"] = "\u227A",
        [@"\H{o}"] = "\u0151",
        [@"\mldr"] = "\u2026",
        [@"\""{y}"] = "\u00FD",
        [@"\cong"] = "\u2245",
        [@"\.{e}"] = "\u0117",
        [@"\""{L}"] = "\u0139",
        [@"\star"] = "\u002A",
        [@"\.{Z}"] = "\u017B",
        [@"\""{e}"] = "\u00E9",
        [@"\geqq"] = "\u2267",
        [@"\cdot"] = "\u22C5",
        [@"\`{U}"] = "\u00D9",
        [@"\""{l}"] = "\u013A",
        [@"\v{L}"] = "\u013D",
        [@"\c{s}"] = "\u015F",
        [@"\""{s}"] = "\u015B",
        [@"\~{A}"] = "\u00C3",
        [@"\Vert"] = "\u2016",
        [@"\k{e}"] = "\u0119",
        [@"\lnot"] = "\u00AC",
        [@"\""{z}"] = "\u017A",
        [@"\leqq"] = "\u2266",
        [@"\beth"] = "\u2136",
        [@"\""{E}"] = "\u00C9",
        [@"\~{n}"] = "\u00F1",
        [@"\u{i}"] = "\u0439",
        [@"\c{S}"] = "\u015E",
        [@"\c{N}"] = "\u0145",
        [@"\H{u}"] = "\u0171",
        [@"\v{n}"] = "\u0148",
        [@"\""{S}"] = "\u015A",
        [@"\={U}"] = "\u016A",
        [@"\~{O}"] = "\u00D5",
        [@"\""{Z}"] = "\u0179",
        [@"\v{E}"] = "\u011A",
        [@"\""{R}"] = "\u0154",
        [@"\H{U}"] = "\u0170",
        [@"\v{N}"] = "\u0147",
        [@"\prod"] = "\u220F",
        [@"\v{s}"] = "\u0161",
        [@"\""{U}"] = "\u00DC",
        [@"\c{n}"] = "\u0146",
        [@"\k{U}"] = "\u0172",
        [@"\c{R}"] = "\u0156",
        [@"\""{A}"] = "\u00C1",
        [@"\~{o}"] = "\u00F5",
        [@"\v{e}"] = "\u011B",
        [@"\v{S}"] = "\u0160",
        [@"\u{A}"] = "\u0102",
        [@"\circ"] = "\u2218",
        [@"\""{u}"] = "\u00FC",
        [@"\flat"] = "\u266D",
        [@"\v{z}"] = "\u017E",
        [@"\r{U}"] = "\u016E",
        [@"\`{O}"] = "\u00D2",
        [@"\={u}"] = "\u016B",
        [@"\oint"] = "\u222E",
        [@"\c{K}"] = "\u0136",
        [@"\k{u}"] = "\u0173",
        [@"\not<"] = "\u226E",
        [@"\not>"] = "\u226F",
        [@"\`{o}"] = "\u00F2",
        [@"\""{I}"] = "\u00CF",
        [@"\v{D}"] = "\u010E",
        [@"\.{G}"] = "\u0120",
        [@"\r{u}"] = "\u016F",
        [@"\not="] = "\u2260",
        [@"\`{u}"] = "\u00F9",
        [@"\v{c}"] = "\u010D",
        [@"\c{k}"] = "\u0137",
        [@"\.{g}"] = "\u0121",
        [@"\""{N}"] = "\u0143",
        [@"\odot"] = "\u2299",
        [@"\`{e}"] = "\u044D",
        [@"\c{T}"] = "\u0162",
        [@"\v{d}"] = "\u010F",
        [@"\""{e}"] = "\u0451",
        [@"\""{I}"] = "\u00CD",
        [@"\v{R}"] = "\u0158",
        [@"\k{a}"] = "\u0105",
        [@"\nldr"] = "\u2025",
        [@"\`{A}"] = "\u00C0",
        [@"\""{n}"] = "\u0144",
        [@"\~{N}"] = "\u00D1",
        [@"\nmid"] = "\u2224",
        [@"\.{C}"] = "\u010A",
        [@"\zeta"] = "\u03B6",
        [@"\~{u}"] = "\u0169",
        [@"\`{E}"] = "\u042D",
        [@"\~{a}"] = "\u00E3",
        [@"\c{t}"] = "\u0163",
        [@"\={o}"] = "\u014D",
        [@"\v{r}"] = "\u0159",
        [@"\={A}"] = "\u0100",
        [@"\.{c}"] = "\u010B",
        [@"\~{U}"] = "\u0168",
        [@"\k{A}"] = "\u0104",
        [@"\""{a}"] = "\u00E4",
        [@"\u{U}"] = "\u040E",
        [@"\iota"] = "\u03B9",
        [@"\={O}"] = "\u014C",
        [@"\c{C}"] = "\u00C7",
        [@"\gneq"] = "\u2269",
        [@"\""{c}"] = "\u0107",
        [@"\boxH"] = "\u2550",
        [@"\hbar"] = "\u210F",
        [@"\""{A}"] = "\u00C4",
        [@"\boxv"] = "\u2502",
        [@"\boxh"] = "\u2500",
        [@"\male"] = "\u2642",
        [@"\""{u}"] = "\u00FA",
        [@"\sqrt"] = "\u221A",
        [@"\succ"] = "\u227B",
        [@"\c{c}"] = "\u00E7",
        [@"\""{C}"] = "\u0106",
        [@"\v{l}"] = "\u013E",
        [@"\u{a}"] = "\u0103",
        [@"\v{Z}"] = "\u017D",
        [@"\""{o}"] = "\u00F3",
        [@"\c{G}"] = "\u0122",
        [@"\v{C}"] = "\u010C",
        [@"\lneq"] = "\u2268",
        [@"\""{E}"] = "\u0401",
        [@"\={a}"] = "\u0101",
        [@"\c{l}"] = "\u013C",
        [@"\""{a}"] = "\u00E1",
        [@"\={E}"] = "\u0112",
        [@"\boxV"] = "\u2551",
        [@"\u{g}"] = "\u011F",
        [@"\""{O}"] = "\u00D3",
        [@"\""{g}"] = "\u01F5",
        [@"\u{I}"] = "\u0419",
        [@"\c{L}"] = "\u013B",
        [@"\k{E}"] = "\u0118",
        [@"\.{I}"] = "\u0130",
        [@"\~{I}"] = "\u0128",
        [@"\quad"] = "\u2003",
        [@"\c{r}"] = "\u0157",
        [@"\""{r}"] = "\u0155",
        [@"\""{Y}"] = "\u0178",
        [@"\={e}"] = "\u0113",
        [@"\""{U}"] = "\u00DA",
        [@"\leq"] = "\u2264",
        [@"\Cup"] = "\u22D3",
        [@"\Psi"] = "\u03A8",
        [@"\neq"] = "\u2260",
        [@"\k{}"] = "\u02DB",
        [@"\={}"] = "\u203E",
        [@"\H{}"] = "\u02DD",
        [@"\cup"] = "\u222A",
        [@"\geq"] = "\u2265",
        [@"\mho"] = "\u2127",
        [@"\Dzh"] = "\u040F",
        [@"\cap"] = "\u2229",
        [@"\bot"] = "\u22A5",
        [@"\psi"] = "\u03C8",
        [@"\chi"] = "\u03C7",
        [@"\c{}"] = "\u00B8",
        [@"\Phi"] = "\u03A6",
        [@"\ast"] = "\u002A",
        [@"\ell"] = "\u2113",
        [@"\top"] = "\u22A4",
        [@"\lll"] = "\u22D8",
        [@"\tau"] = "\u03C4",
        [@"\Cap"] = "\u22D2",
        [@"\sad"] = "\u2639",
        [@"\iff"] = "\u21D4",
        [@"\eta"] = "\u03B7",
        [@"\eth"] = "\u00F0",
        [@"\d{}"] = "\u0323",
        [@"\rho"] = "\u03C1",
        [@"\dzh"] = "\u045F",
        [@"\div"] = "\u00F7",
        [@"\phi"] = "\u03C6",
        [@"\Rsh"] = "\u21B1",
        [@"\vee"] = "\u2228",
        [@"\b{}"] = "\u02CD",
        [@"\t{}"] = "\u0361",
        [@"\int"] = "\u222B",
        [@"\sim"] = "\u223C",
        [@"\r{}"] = "\u02DA",
        [@"\Lsh"] = "\u21B0",
        [@"\yen"] = "\u00A5",
        [@"\ggg"] = "\u22D9",
        [@"\mid"] = "\u2223",
        [@"\sum"] = "\u2211",
        [@"\Dz"] = "\u0405",
        [@"\Re"] = "\u211C",
        [@"\oe"] = "\u0153",
        [@"\DH"] = "\u00D0",
        [@"\ll"] = "\u226A",
        [@"\ng"] = "\u014B",
        [@"\""G"] = "\u0403",
        [@"\wr"] = "\u2240",
        [@"\wp"] = "\u2118",
        [@"\=I"] = "\u0406",
        [@"\:)"] = "\u263A",
        [@"\:("] = "\u2639",
        [@"\AE"] = "\u00C6",
        [@"\AA"] = "\u00C5",
        [@"\ss"] = "\u00DF",
        [@"\dz"] = "\u0455",
        [@"\ae"] = "\u00E6",
        [@"\aa"] = "\u00E5",
        [@"\th"] = "\u00FE",
        [@"\to"] = "\u2192",
        [@"\Pi"] = "\u03A0",
        [@"\mp"] = "\u2213",
        [@"\Im"] = "\u2111",
        [@"\pm"] = "\u00B1",
        [@"\pi"] = "\u03C0",
        [@"\""I"] = "\u0407",
        [@"\""C"] = "\u040B",
        [@"\in"] = "\u2208",
        [@"\""K"] = "\u040C",
        [@"\""k"] = "\u045C",
        [@"\""c"] = "\u045B",
        [@"\""g"] = "\u0453",
        [@"\ni"] = "\u220B",
        [@"\ne"] = "\u2260",
        [@"\TH"] = "\u00DE",
        [@"\Xi"] = "\u039E",
        [@"\nu"] = "\u03BD",
        [@"\NG"] = "\u014A",
        [@"\:G"] = "\u32E1",
        [@"\xi"] = "\u03BE",
        [@"\OE"] = "\u0152",
        [@"\gg"] = "\u226B",
        [@"\DJ"] = "\u0110",
        [@"\=e"] = "\u0454",
        [@"\=E"] = "\u0404",
        [@"\mu"] = "\u03BC",
        [@"\dj"] = "\u0111",
        [@"\:"] = "\u2004",
        [@"\;"] = "\u2002",
        [@"\&"] = "\u0026",
        [@"\$"] = "\u0024",
        [@"\%"] = "\u0025",
        [@"\#"] = "\u0023",
        [@"\,"] = "\u2009",
        [@"\-"] = "\u00AD",
        [@"\S"] = "\u00A7",
        [@"\P"] = "\u00B6",
        [@"\O"] = "\u00D8",
        [@"\L"] = "\u0141",
        [@"\}"] = "\u007D",
        [@"\o"] = "\u00F8",
        [@"\l"] = "\u0142",
        [@"\h"] = "\u210E",
        [@"\i"] = "\u2139",
    };
}