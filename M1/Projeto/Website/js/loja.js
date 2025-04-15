/** Esta DB respeita o formato { "ISBN": "< ISBN >", "titulo": "< titulo >", "autor": "< autor >", "categoria": "< categoria >",
 * "preco": < preco >,  "promocao":  < promocao >,  "rating":  < rating >,  "imagem": "< ficheiro >" }, onde promoção é o valor de compra
 * do curso e as propriedades "preco", "promocao" e "rating" são valores numéricos. */
const db = [
	{
		ISBN: "978-1-01-001234-6",
		titulo: "Web para Principiantes",
		autor: "Maria da Internet",
		categoria: "tecnologia",
		preco: 250,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001235-3",
		titulo: "JavaScript Avançado",
		autor: "João Script",
		categoria: "tecnologia",
		preco: 320,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001236-0",
		titulo: "Python para Todos",
		autor: "Ana Codadora",
		categoria: "tecnologia",
		preco: 400,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001237-7",
		titulo: "HTML e CSS Descomplicados",
		autor: "Carlos Designer",
		categoria: "tecnologia",
		preco: 180,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001238-4",
		titulo: "Introdução ao PHP",
		autor: "Pedro Backend",
		categoria: "tecnologia",
		preco: 300,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001239-1",
		titulo: "Desenvolvimento Ágil com Scrum",
		autor: "Sara Produtiva",
		categoria: "tecnologia",
		preco: 280,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001240-7",
		titulo: "Noções Básicas de Redes",
		autor: "Lucas Networking",
		categoria: "tecnologia",
		preco: 250,
		promocao: 18,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001241-4",
		titulo: "Fundamentos de Cybersegurança",
		autor: "Patrícia Segura",
		categoria: "tecnologia",
		preco: 370,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001242-1",
		titulo: "Machine Learning Prático",
		autor: "Leonardo AI",
		categoria: "tecnologia",
		preco: 500,
		promocao: 35,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001243-8",
		titulo: "Marketing Digital para Iniciantes",
		autor: "Mariana Promoção",
		categoria: "negócios",
		preco: 200,
		promocao: 28,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001244-5",
		titulo: "Estratégias de SEO",
		autor: "Fábio Otimizado",
		categoria: "negócios",
		preco: 180,
		promocao: 20,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001245-2",
		titulo: "Gestão de Projetos com Kanban",
		autor: "Eduardo Fluxo",
		categoria: "negócios",
		preco: 270,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001246-9",
		titulo: "Design Gráfico Moderno",
		autor: "Beatriz Criativa",
		categoria: "design",
		preco: 260,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001247-6",
		titulo: "Photoshop do Zero ao Avançado",
		autor: "Lúcia Editora",
		categoria: "design",
		preco: 350,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001248-3",
		titulo: "UX e UI para Desenvolvedores",
		autor: "Bruno Experiência",
		categoria: "design",
		preco: 240,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001249-0",
		titulo: "Introdução ao Data Science",
		autor: "Gabriela Análise",
		categoria: "tecnologia",
		preco: 380,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001250-6",
		titulo: "SQL para Banco de Dados",
		autor: "Renato Consultor",
		categoria: "tecnologia",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001251-3",
		titulo: "Blockchain e Criptomoedas",
		autor: "Victor Blockchain",
		categoria: "tecnologia",
		preco: 480,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001252-0",
		titulo: "Fundamentos de Estatística",
		autor: "Camila Matemática",
		categoria: "educação",
		preco: 220,
		promocao: 18,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001253-7",
		titulo: "A Arte do Storytelling",
		autor: "Fernanda Escritora",
		categoria: "comunicação",
		preco: 190,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001254-4",
		titulo: "Técnicas de Apresentação em Público",
		autor: "André Orador",
		categoria: "comunicação",
		preco: 280,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001255-1",
		titulo: "Cozinhando com Amor",
		autor: "Joana Chef",
		categoria: "culinária",
		preco: 150,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001256-8",
		titulo: "Receitas Vegetarianas",
		autor: "Lara Vegetal",
		categoria: "culinária",
		preco: 210,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001257-5",
		titulo: "Mundo dos Doces",
		autor: "Paulo Confeiteiro",
		categoria: "culinária",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001258-2",
		titulo: "Jardinagem Básica",
		autor: "Roberta Verde",
		categoria: "lazer",
		preco: 180,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001259-9",
		titulo: "Fotografia para Iniciantes",
		autor: "Rafael Lentes",
		categoria: "fotografia",
		preco: 260,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001260-5",
		titulo: "Técnicas de Edição de Vídeo",
		autor: "Mateus Editor",
		categoria: "fotografia",
		preco: 350,
		promocao: 28,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001261-2",
		titulo: "Torne-se um Produtor Musical",
		autor: "Alessandro Som",
		categoria: "música",
		preco: 400,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001262-9",
		titulo: "História da Música Clássica",
		autor: "Julia Melodia",
		categoria: "música",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001263-6",
		titulo: "Como Tocar Violão",
		autor: "Rodrigo Cordas",
		categoria: "música",
		preco: 220,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001264-3",
		titulo: "Guia de Programação Neurolinguística",
		autor: "Sofia Mente",
		categoria: "desenvolvimento pessoal",
		preco: 240,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001265-0",
		titulo: "Mindfulness no Trabalho",
		autor: "Thiago Zen",
		categoria: "desenvolvimento pessoal",
		preco: 190,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001266-7",
		titulo: "Meditação para Todos",
		autor: "Marcelo Paz",
		categoria: "desenvolvimento pessoal",
		preco: 210,
		promocao: 10,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001267-4",
		titulo: "Inteligência Emocional no Trabalho",
		autor: "Letícia Equilíbrio",
		categoria: "desenvolvimento pessoal",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001268-1",
		titulo: "História do Antigo Egito",
		autor: "Miguel Faraó",
		categoria: "história",
		preco: 320,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001269-8",
		titulo: "Guia de Arqueologia",
		autor: "Carla Exploração",
		categoria: "história",
		preco: 250,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001270-4",
		titulo: "Segunda Guerra Mundial: Uma Perspectiva",
		autor: "Henrique Guerra",
		categoria: "história",
		preco: 280,
		promocao: 22,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001271-1",
		titulo: "Cultura Pop Japonesa",
		autor: "Aline Anime",
		categoria: "cultura",
		preco: 300,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001272-8",
		titulo: "Mitologia Grega",
		autor: "Clara Olimpo",
		categoria: "cultura",
		preco: 270,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001273-5",
		titulo: "Mitologia Nórdica",
		autor: "Gustavo Thor",
		categoria: "cultura",
		preco: 260,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001274-2",
		titulo: "Ciência dos Materiais",
		autor: "Felipe Elementar",
		categoria: "ciências",
		preco: 400,
		promocao: 20,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001275-9",
		titulo: "Astrofísica Moderna",
		autor: "Natália Estrelas",
		categoria: "ciências",
		preco: 380,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001276-6",
		titulo: "Introdução à Biologia Molecular",
		autor: "Victor Genoma",
		categoria: "ciências",
		preco: 350,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001277-3",
		titulo: "Sistemas Operacionais",
		autor: "Alice Kernel",
		categoria: "tecnologia",
		preco: 370,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001278-0",
		titulo: "Programação Funcional com Haskell",
		autor: "Marcos Lambda",
		categoria: "tecnologia",
		preco: 420,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001234-6",
		titulo: "Web para Principiantes",
		autor: "Maria da Internet",
		categoria: "tecnologia",
		preco: 250,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001235-3",
		titulo: "JavaScript Avançado",
		autor: "João Script",
		categoria: "tecnologia",
		preco: 320,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001236-0",
		titulo: "Python para Todos",
		autor: "Ana Codadora",
		categoria: "tecnologia",
		preco: 400,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001237-7",
		titulo: "HTML e CSS Descomplicados",
		autor: "Carlos Designer",
		categoria: "tecnologia",
		preco: 180,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001238-4",
		titulo: "Introdução ao PHP",
		autor: "Pedro Backend",
		categoria: "tecnologia",
		preco: 300,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001239-1",
		titulo: "Desenvolvimento Ágil com Scrum",
		autor: "Sara Produtiva",
		categoria: "tecnologia",
		preco: 280,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001240-7",
		titulo: "Noções Básicas de Redes",
		autor: "Lucas Networking",
		categoria: "tecnologia",
		preco: 250,
		promocao: 18,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001241-4",
		titulo: "Fundamentos de Cybersegurança",
		autor: "Patrícia Segura",
		categoria: "tecnologia",
		preco: 370,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001242-1",
		titulo: "Machine Learning Prático",
		autor: "Leonardo AI",
		categoria: "tecnologia",
		preco: 500,
		promocao: 35,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001243-8",
		titulo: "Marketing Digital para Iniciantes",
		autor: "Mariana Promoção",
		categoria: "negócios",
		preco: 200,
		promocao: 28,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001244-5",
		titulo: "Estratégias de SEO",
		autor: "Fábio Otimizado",
		categoria: "negócios",
		preco: 180,
		promocao: 20,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001245-2",
		titulo: "Gestão de Projetos com Kanban",
		autor: "Eduardo Fluxo",
		categoria: "negócios",
		preco: 270,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001246-9",
		titulo: "Design Gráfico Moderno",
		autor: "Beatriz Criativa",
		categoria: "design",
		preco: 260,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001247-6",
		titulo: "Photoshop do Zero ao Avançado",
		autor: "Lúcia Editora",
		categoria: "design",
		preco: 350,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001248-3",
		titulo: "UX e UI para Desenvolvedores",
		autor: "Bruno Experiência",
		categoria: "design",
		preco: 240,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001249-0",
		titulo: "Introdução ao Data Science",
		autor: "Gabriela Análise",
		categoria: "tecnologia",
		preco: 380,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001250-6",
		titulo: "SQL para Banco de Dados",
		autor: "Renato Consultor",
		categoria: "tecnologia",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001251-3",
		titulo: "Blockchain e Criptomoedas",
		autor: "Victor Blockchain",
		categoria: "tecnologia",
		preco: 480,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001252-0",
		titulo: "Fundamentos de Estatística",
		autor: "Camila Matemática",
		categoria: "educação",
		preco: 220,
		promocao: 18,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001253-7",
		titulo: "A Arte do Storytelling",
		autor: "Fernanda Escritora",
		categoria: "comunicação",
		preco: 190,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001254-4",
		titulo: "Técnicas de Apresentação em Público",
		autor: "André Orador",
		categoria: "comunicação",
		preco: 280,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001255-1",
		titulo: "Cozinhando com Amor",
		autor: "Joana Chef",
		categoria: "culinária",
		preco: 150,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001256-8",
		titulo: "Receitas Vegetarianas",
		autor: "Lara Vegetal",
		categoria: "culinária",
		preco: 210,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001257-5",
		titulo: "Mundo dos Doces",
		autor: "Paulo Confeiteiro",
		categoria: "culinária",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001258-2",
		titulo: "Jardinagem Básica",
		autor: "Roberta Verde",
		categoria: "lazer",
		preco: 180,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001259-9",
		titulo: "Fotografia para Iniciantes",
		autor: "Rafael Lentes",
		categoria: "fotografia",
		preco: 260,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001260-5",
		titulo: "Técnicas de Edição de Vídeo",
		autor: "Mateus Editor",
		categoria: "fotografia",
		preco: 350,
		promocao: 28,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001261-2",
		titulo: "Torne-se um Produtor Musical",
		autor: "Alessandro Som",
		categoria: "música",
		preco: 400,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001262-9",
		titulo: "História da Música Clássica",
		autor: "Julia Melodia",
		categoria: "música",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001263-6",
		titulo: "Como Tocar Violão",
		autor: "Rodrigo Cordas",
		categoria: "música",
		preco: 220,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001264-3",
		titulo: "Guia de Programação Neurolinguística",
		autor: "Sofia Mente",
		categoria: "desenvolvimento pessoal",
		preco: 240,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001265-0",
		titulo: "Mindfulness no Trabalho",
		autor: "Thiago Zen",
		categoria: "desenvolvimento pessoal",
		preco: 190,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001266-7",
		titulo: "Meditação para Todos",
		autor: "Marcelo Paz",
		categoria: "desenvolvimento pessoal",
		preco: 210,
		promocao: 10,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001267-4",
		titulo: "Inteligência Emocional no Trabalho",
		autor: "Letícia Equilíbrio",
		categoria: "desenvolvimento pessoal",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001268-1",
		titulo: "História do Antigo Egito",
		autor: "Miguel Faraó",
		categoria: "história",
		preco: 320,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001269-8",
		titulo: "Guia de Arqueologia",
		autor: "Carla Exploração",
		categoria: "história",
		preco: 250,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001270-4",
		titulo: "Segunda Guerra Mundial: Uma Perspectiva",
		autor: "Henrique Guerra",
		categoria: "história",
		preco: 280,
		promocao: 22,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001271-1",
		titulo: "Cultura Pop Japonesa",
		autor: "Aline Anime",
		categoria: "cultura",
		preco: 300,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001272-8",
		titulo: "Mitologia Grega",
		autor: "Clara Olimpo",
		categoria: "cultura",
		preco: 270,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001273-5",
		titulo: "Mitologia Nórdica",
		autor: "Gustavo Thor",
		categoria: "cultura",
		preco: 260,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001274-2",
		titulo: "Ciência dos Materiais",
		autor: "Felipe Elementar",
		categoria: "ciências",
		preco: 400,
		promocao: 20,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001275-9",
		titulo: "Astrofísica Moderna",
		autor: "Natália Estrelas",
		categoria: "ciências",
		preco: 380,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001276-6",
		titulo: "Introdução à Biologia Molecular",
		autor: "Victor Genoma",
		categoria: "ciências",
		preco: 350,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001277-3",
		titulo: "Sistemas Operacionais",
		autor: "Alice Kernel",
		categoria: "tecnologia",
		preco: 370,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001278-0",
		titulo: "Programação Funcional com Haskell",
		autor: "Marcos Lambda",
		categoria: "tecnologia",
		preco: 420,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001234-6",
		titulo: "Web para Principiantes",
		autor: "Maria da Internet",
		categoria: "tecnologia",
		preco: 250,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001235-3",
		titulo: "JavaScript Avançado",
		autor: "João Script",
		categoria: "tecnologia",
		preco: 320,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001236-0",
		titulo: "Python para Todos",
		autor: "Ana Codadora",
		categoria: "tecnologia",
		preco: 400,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001237-7",
		titulo: "HTML e CSS Descomplicados",
		autor: "Carlos Designer",
		categoria: "tecnologia",
		preco: 180,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001238-4",
		titulo: "Introdução ao PHP",
		autor: "Pedro Backend",
		categoria: "tecnologia",
		preco: 300,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001239-1",
		titulo: "Desenvolvimento Ágil com Scrum",
		autor: "Sara Produtiva",
		categoria: "tecnologia",
		preco: 280,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001240-7",
		titulo: "Noções Básicas de Redes",
		autor: "Lucas Networking",
		categoria: "tecnologia",
		preco: 250,
		promocao: 18,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001241-4",
		titulo: "Fundamentos de Cybersegurança",
		autor: "Patrícia Segura",
		categoria: "tecnologia",
		preco: 370,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001242-1",
		titulo: "Machine Learning Prático",
		autor: "Leonardo AI",
		categoria: "tecnologia",
		preco: 500,
		promocao: 35,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001243-8",
		titulo: "Marketing Digital para Iniciantes",
		autor: "Mariana Promoção",
		categoria: "negócios",
		preco: 200,
		promocao: 28,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001244-5",
		titulo: "Estratégias de SEO",
		autor: "Fábio Otimizado",
		categoria: "negócios",
		preco: 180,
		promocao: 20,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001245-2",
		titulo: "Gestão de Projetos com Kanban",
		autor: "Eduardo Fluxo",
		categoria: "negócios",
		preco: 270,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001246-9",
		titulo: "Design Gráfico Moderno",
		autor: "Beatriz Criativa",
		categoria: "design",
		preco: 260,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001247-6",
		titulo: "Photoshop do Zero ao Avançado",
		autor: "Lúcia Editora",
		categoria: "design",
		preco: 350,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001248-3",
		titulo: "UX e UI para Desenvolvedores",
		autor: "Bruno Experiência",
		categoria: "design",
		preco: 240,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001249-0",
		titulo: "Introdução ao Data Science",
		autor: "Gabriela Análise",
		categoria: "tecnologia",
		preco: 380,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001250-6",
		titulo: "SQL para Banco de Dados",
		autor: "Renato Consultor",
		categoria: "tecnologia",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001251-3",
		titulo: "Blockchain e Criptomoedas",
		autor: "Victor Blockchain",
		categoria: "tecnologia",
		preco: 480,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001252-0",
		titulo: "Fundamentos de Estatística",
		autor: "Camila Matemática",
		categoria: "educação",
		preco: 220,
		promocao: 18,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001253-7",
		titulo: "A Arte do Storytelling",
		autor: "Fernanda Escritora",
		categoria: "comunicação",
		preco: 190,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001254-4",
		titulo: "Técnicas de Apresentação em Público",
		autor: "André Orador",
		categoria: "comunicação",
		preco: 280,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001255-1",
		titulo: "Cozinhando com Amor",
		autor: "Joana Chef",
		categoria: "culinária",
		preco: 150,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001256-8",
		titulo: "Receitas Vegetarianas",
		autor: "Lara Vegetal",
		categoria: "culinária",
		preco: 210,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001257-5",
		titulo: "Mundo dos Doces",
		autor: "Paulo Confeiteiro",
		categoria: "culinária",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001258-2",
		titulo: "Jardinagem Básica",
		autor: "Roberta Verde",
		categoria: "lazer",
		preco: 180,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001259-9",
		titulo: "Fotografia para Iniciantes",
		autor: "Rafael Lentes",
		categoria: "fotografia",
		preco: 260,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001260-5",
		titulo: "Técnicas de Edição de Vídeo",
		autor: "Mateus Editor",
		categoria: "fotografia",
		preco: 350,
		promocao: 28,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001261-2",
		titulo: "Torne-se um Produtor Musical",
		autor: "Alessandro Som",
		categoria: "música",
		preco: 400,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001262-9",
		titulo: "História da Música Clássica",
		autor: "Julia Melodia",
		categoria: "música",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001263-6",
		titulo: "Como Tocar Violão",
		autor: "Rodrigo Cordas",
		categoria: "música",
		preco: 220,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001264-3",
		titulo: "Guia de Programação Neurolinguística",
		autor: "Sofia Mente",
		categoria: "desenvolvimento pessoal",
		preco: 240,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001265-0",
		titulo: "Mindfulness no Trabalho",
		autor: "Thiago Zen",
		categoria: "desenvolvimento pessoal",
		preco: 190,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001266-7",
		titulo: "Meditação para Todos",
		autor: "Marcelo Paz",
		categoria: "desenvolvimento pessoal",
		preco: 210,
		promocao: 10,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001267-4",
		titulo: "Inteligência Emocional no Trabalho",
		autor: "Letícia Equilíbrio",
		categoria: "desenvolvimento pessoal",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001268-1",
		titulo: "História do Antigo Egito",
		autor: "Miguel Faraó",
		categoria: "história",
		preco: 320,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001269-8",
		titulo: "Guia de Arqueologia",
		autor: "Carla Exploração",
		categoria: "história",
		preco: 250,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001270-4",
		titulo: "Segunda Guerra Mundial: Uma Perspectiva",
		autor: "Henrique Guerra",
		categoria: "história",
		preco: 280,
		promocao: 22,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001271-1",
		titulo: "Cultura Pop Japonesa",
		autor: "Aline Anime",
		categoria: "cultura",
		preco: 300,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001272-8",
		titulo: "Mitologia Grega",
		autor: "Clara Olimpo",
		categoria: "cultura",
		preco: 270,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001273-5",
		titulo: "Mitologia Nórdica",
		autor: "Gustavo Thor",
		categoria: "cultura",
		preco: 260,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001274-2",
		titulo: "Ciência dos Materiais",
		autor: "Felipe Elementar",
		categoria: "ciências",
		preco: 400,
		promocao: 20,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001275-9",
		titulo: "Astrofísica Moderna",
		autor: "Natália Estrelas",
		categoria: "ciências",
		preco: 380,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001276-6",
		titulo: "Introdução à Biologia Molecular",
		autor: "Victor Genoma",
		categoria: "ciências",
		preco: 350,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001277-3",
		titulo: "Sistemas Operacionais",
		autor: "Alice Kernel",
		categoria: "tecnologia",
		preco: 370,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001278-0",
		titulo: "Programação Funcional com Haskell",
		autor: "Marcos Lambda",
		categoria: "tecnologia",
		preco: 420,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001234-6",
		titulo: "Web para Principiantes",
		autor: "Maria da Internet",
		categoria: "tecnologia",
		preco: 250,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001235-3",
		titulo: "JavaScript Avançado",
		autor: "João Script",
		categoria: "tecnologia",
		preco: 320,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001236-0",
		titulo: "Python para Todos",
		autor: "Ana Codadora",
		categoria: "tecnologia",
		preco: 400,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001237-7",
		titulo: "HTML e CSS Descomplicados",
		autor: "Carlos Designer",
		categoria: "tecnologia",
		preco: 180,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001238-4",
		titulo: "Introdução ao PHP",
		autor: "Pedro Backend",
		categoria: "tecnologia",
		preco: 300,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001239-1",
		titulo: "Desenvolvimento Ágil com Scrum",
		autor: "Sara Produtiva",
		categoria: "tecnologia",
		preco: 280,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001240-7",
		titulo: "Noções Básicas de Redes",
		autor: "Lucas Networking",
		categoria: "tecnologia",
		preco: 250,
		promocao: 18,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001241-4",
		titulo: "Fundamentos de Cybersegurança",
		autor: "Patrícia Segura",
		categoria: "tecnologia",
		preco: 370,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001242-1",
		titulo: "Machine Learning Prático",
		autor: "Leonardo AI",
		categoria: "tecnologia",
		preco: 500,
		promocao: 35,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001243-8",
		titulo: "Marketing Digital para Iniciantes",
		autor: "Mariana Promoção",
		categoria: "negócios",
		preco: 200,
		promocao: 28,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001244-5",
		titulo: "Estratégias de SEO",
		autor: "Fábio Otimizado",
		categoria: "negócios",
		preco: 180,
		promocao: 20,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001245-2",
		titulo: "Gestão de Projetos com Kanban",
		autor: "Eduardo Fluxo",
		categoria: "negócios",
		preco: 270,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001246-9",
		titulo: "Design Gráfico Moderno",
		autor: "Beatriz Criativa",
		categoria: "design",
		preco: 260,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001247-6",
		titulo: "Photoshop do Zero ao Avançado",
		autor: "Lúcia Editora",
		categoria: "design",
		preco: 350,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001248-3",
		titulo: "UX e UI para Desenvolvedores",
		autor: "Bruno Experiência",
		categoria: "design",
		preco: 240,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001249-0",
		titulo: "Introdução ao Data Science",
		autor: "Gabriela Análise",
		categoria: "tecnologia",
		preco: 380,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001250-6",
		titulo: "SQL para Banco de Dados",
		autor: "Renato Consultor",
		categoria: "tecnologia",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001251-3",
		titulo: "Blockchain e Criptomoedas",
		autor: "Victor Blockchain",
		categoria: "tecnologia",
		preco: 480,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001252-0",
		titulo: "Fundamentos de Estatística",
		autor: "Camila Matemática",
		categoria: "educação",
		preco: 220,
		promocao: 18,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001253-7",
		titulo: "A Arte do Storytelling",
		autor: "Fernanda Escritora",
		categoria: "comunicação",
		preco: 190,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001254-4",
		titulo: "Técnicas de Apresentação em Público",
		autor: "André Orador",
		categoria: "comunicação",
		preco: 280,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001255-1",
		titulo: "Cozinhando com Amor",
		autor: "Joana Chef",
		categoria: "culinária",
		preco: 150,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001256-8",
		titulo: "Receitas Vegetarianas",
		autor: "Lara Vegetal",
		categoria: "culinária",
		preco: 210,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001257-5",
		titulo: "Mundo dos Doces",
		autor: "Paulo Confeiteiro",
		categoria: "culinária",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001258-2",
		titulo: "Jardinagem Básica",
		autor: "Roberta Verde",
		categoria: "lazer",
		preco: 180,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001259-9",
		titulo: "Fotografia para Iniciantes",
		autor: "Rafael Lentes",
		categoria: "fotografia",
		preco: 260,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001260-5",
		titulo: "Técnicas de Edição de Vídeo",
		autor: "Mateus Editor",
		categoria: "fotografia",
		preco: 350,
		promocao: 28,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001261-2",
		titulo: "Torne-se um Produtor Musical",
		autor: "Alessandro Som",
		categoria: "música",
		preco: 400,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001262-9",
		titulo: "História da Música Clássica",
		autor: "Julia Melodia",
		categoria: "música",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001263-6",
		titulo: "Como Tocar Violão",
		autor: "Rodrigo Cordas",
		categoria: "música",
		preco: 220,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001264-3",
		titulo: "Guia de Programação Neurolinguística",
		autor: "Sofia Mente",
		categoria: "desenvolvimento pessoal",
		preco: 240,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001265-0",
		titulo: "Mindfulness no Trabalho",
		autor: "Thiago Zen",
		categoria: "desenvolvimento pessoal",
		preco: 190,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001266-7",
		titulo: "Meditação para Todos",
		autor: "Marcelo Paz",
		categoria: "desenvolvimento pessoal",
		preco: 210,
		promocao: 10,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001267-4",
		titulo: "Inteligência Emocional no Trabalho",
		autor: "Letícia Equilíbrio",
		categoria: "desenvolvimento pessoal",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001268-1",
		titulo: "História do Antigo Egito",
		autor: "Miguel Faraó",
		categoria: "história",
		preco: 320,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001269-8",
		titulo: "Guia de Arqueologia",
		autor: "Carla Exploração",
		categoria: "história",
		preco: 250,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001270-4",
		titulo: "Segunda Guerra Mundial: Uma Perspectiva",
		autor: "Henrique Guerra",
		categoria: "história",
		preco: 280,
		promocao: 22,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001271-1",
		titulo: "Cultura Pop Japonesa",
		autor: "Aline Anime",
		categoria: "cultura",
		preco: 300,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001272-8",
		titulo: "Mitologia Grega",
		autor: "Clara Olimpo",
		categoria: "cultura",
		preco: 270,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001273-5",
		titulo: "Mitologia Nórdica",
		autor: "Gustavo Thor",
		categoria: "cultura",
		preco: 260,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001274-2",
		titulo: "Ciência dos Materiais",
		autor: "Felipe Elementar",
		categoria: "ciências",
		preco: 400,
		promocao: 20,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001275-9",
		titulo: "Astrofísica Moderna",
		autor: "Natália Estrelas",
		categoria: "ciências",
		preco: 380,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001276-6",
		titulo: "Introdução à Biologia Molecular",
		autor: "Victor Genoma",
		categoria: "ciências",
		preco: 350,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001277-3",
		titulo: "Sistemas Operacionais",
		autor: "Alice Kernel",
		categoria: "tecnologia",
		preco: 370,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001278-0",
		titulo: "Programação Funcional com Haskell",
		autor: "Marcos Lambda",
		categoria: "tecnologia",
		preco: 420,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001234-6",
		titulo: "Web para Principiantes",
		autor: "Maria da Internet",
		categoria: "tecnologia",
		preco: 250,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001235-3",
		titulo: "JavaScript Avançado",
		autor: "João Script",
		categoria: "tecnologia",
		preco: 320,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001236-0",
		titulo: "Python para Todos",
		autor: "Ana Codadora",
		categoria: "tecnologia",
		preco: 400,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001237-7",
		titulo: "HTML e CSS Descomplicados",
		autor: "Carlos Designer",
		categoria: "tecnologia",
		preco: 180,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001238-4",
		titulo: "Introdução ao PHP",
		autor: "Pedro Backend",
		categoria: "tecnologia",
		preco: 300,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001239-1",
		titulo: "Desenvolvimento Ágil com Scrum",
		autor: "Sara Produtiva",
		categoria: "tecnologia",
		preco: 280,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001240-7",
		titulo: "Noções Básicas de Redes",
		autor: "Lucas Networking",
		categoria: "tecnologia",
		preco: 250,
		promocao: 18,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001241-4",
		titulo: "Fundamentos de Cybersegurança",
		autor: "Patrícia Segura",
		categoria: "tecnologia",
		preco: 370,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001242-1",
		titulo: "Machine Learning Prático",
		autor: "Leonardo AI",
		categoria: "tecnologia",
		preco: 500,
		promocao: 35,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001243-8",
		titulo: "Marketing Digital para Iniciantes",
		autor: "Mariana Promoção",
		categoria: "negócios",
		preco: 200,
		promocao: 28,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001244-5",
		titulo: "Estratégias de SEO",
		autor: "Fábio Otimizado",
		categoria: "negócios",
		preco: 180,
		promocao: 20,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001245-2",
		titulo: "Gestão de Projetos com Kanban",
		autor: "Eduardo Fluxo",
		categoria: "negócios",
		preco: 270,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001246-9",
		titulo: "Design Gráfico Moderno",
		autor: "Beatriz Criativa",
		categoria: "design",
		preco: 260,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001247-6",
		titulo: "Photoshop do Zero ao Avançado",
		autor: "Lúcia Editora",
		categoria: "design",
		preco: 350,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001248-3",
		titulo: "UX e UI para Desenvolvedores",
		autor: "Bruno Experiência",
		categoria: "design",
		preco: 240,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001249-0",
		titulo: "Introdução ao Data Science",
		autor: "Gabriela Análise",
		categoria: "tecnologia",
		preco: 380,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001250-6",
		titulo: "SQL para Banco de Dados",
		autor: "Renato Consultor",
		categoria: "tecnologia",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001251-3",
		titulo: "Blockchain e Criptomoedas",
		autor: "Victor Blockchain",
		categoria: "tecnologia",
		preco: 480,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001252-0",
		titulo: "Fundamentos de Estatística",
		autor: "Camila Matemática",
		categoria: "educação",
		preco: 220,
		promocao: 18,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001253-7",
		titulo: "A Arte do Storytelling",
		autor: "Fernanda Escritora",
		categoria: "comunicação",
		preco: 190,
		promocao: 22,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001254-4",
		titulo: "Técnicas de Apresentação em Público",
		autor: "André Orador",
		categoria: "comunicação",
		preco: 280,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001255-1",
		titulo: "Cozinhando com Amor",
		autor: "Joana Chef",
		categoria: "culinária",
		preco: 150,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001256-8",
		titulo: "Receitas Vegetarianas",
		autor: "Lara Vegetal",
		categoria: "culinária",
		preco: 210,
		promocao: 25,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001257-5",
		titulo: "Mundo dos Doces",
		autor: "Paulo Confeiteiro",
		categoria: "culinária",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001258-2",
		titulo: "Jardinagem Básica",
		autor: "Roberta Verde",
		categoria: "lazer",
		preco: 180,
		promocao: 15,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001259-9",
		titulo: "Fotografia para Iniciantes",
		autor: "Rafael Lentes",
		categoria: "fotografia",
		preco: 260,
		promocao: 10,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001260-5",
		titulo: "Técnicas de Edição de Vídeo",
		autor: "Mateus Editor",
		categoria: "fotografia",
		preco: 350,
		promocao: 28,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001261-2",
		titulo: "Torne-se um Produtor Musical",
		autor: "Alessandro Som",
		categoria: "música",
		preco: 400,
		promocao: 30,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001262-9",
		titulo: "História da Música Clássica",
		autor: "Julia Melodia",
		categoria: "música",
		preco: 300,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001263-6",
		titulo: "Como Tocar Violão",
		autor: "Rodrigo Cordas",
		categoria: "música",
		preco: 220,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001264-3",
		titulo: "Guia de Programação Neurolinguística",
		autor: "Sofia Mente",
		categoria: "desenvolvimento pessoal",
		preco: 240,
		promocao: 12,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001265-0",
		titulo: "Mindfulness no Trabalho",
		autor: "Thiago Zen",
		categoria: "desenvolvimento pessoal",
		preco: 190,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001266-7",
		titulo: "Meditação para Todos",
		autor: "Marcelo Paz",
		categoria: "desenvolvimento pessoal",
		preco: 210,
		promocao: 10,
		rating: 3,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001267-4",
		titulo: "Inteligência Emocional no Trabalho",
		autor: "Letícia Equilíbrio",
		categoria: "desenvolvimento pessoal",
		preco: 230,
		promocao: 20,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001268-1",
		titulo: "História do Antigo Egito",
		autor: "Miguel Faraó",
		categoria: "história",
		preco: 320,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001269-8",
		titulo: "Guia de Arqueologia",
		autor: "Carla Exploração",
		categoria: "história",
		preco: 250,
		promocao: 12,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001270-4",
		titulo: "Segunda Guerra Mundial: Uma Perspectiva",
		autor: "Henrique Guerra",
		categoria: "história",
		preco: 280,
		promocao: 22,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001271-1",
		titulo: "Cultura Pop Japonesa",
		autor: "Aline Anime",
		categoria: "cultura",
		preco: 300,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001272-8",
		titulo: "Mitologia Grega",
		autor: "Clara Olimpo",
		categoria: "cultura",
		preco: 270,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001273-5",
		titulo: "Mitologia Nórdica",
		autor: "Gustavo Thor",
		categoria: "cultura",
		preco: 260,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001274-2",
		titulo: "Ciência dos Materiais",
		autor: "Felipe Elementar",
		categoria: "ciências",
		preco: 400,
		promocao: 20,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001275-9",
		titulo: "Astrofísica Moderna",
		autor: "Natália Estrelas",
		categoria: "ciências",
		preco: 380,
		promocao: 25,
		rating: 5,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001276-6",
		titulo: "Introdução à Biologia Molecular",
		autor: "Victor Genoma",
		categoria: "ciências",
		preco: 350,
		promocao: 15,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001277-3",
		titulo: "Sistemas Operacionais",
		autor: "Alice Kernel",
		categoria: "tecnologia",
		preco: 370,
		promocao: 18,
		rating: 4,
		imagem: "curso1.jpg",
	},
	{
		ISBN: "978-1-01-001278-0",
		titulo: "Programação Funcional com Haskell",
		autor: "Marcos Lambda",
		categoria: "tecnologia",
		preco: 420,
		promocao: 30,
		rating: 5,
		imagem: "curso1.jpg",
	},
];

/**
 * The User class represents a user in the system with properties for username, password, favorites, and cart.
 * It provides methods to get user details, add items to favorites, remove items from favorites, and check if an item is in favorites.
 * 
 * Properties:
 * - #_username: The username of the user.
 * - #_password: The password of the user.
 * - #_favorites: An array of favorite items (by ISBN).
 * - #_cart: An array of items in the user's cart.
 * 
 * Methods:
 * - constructor(data): Initializes a new user with the provided data.
 * - getUsername: Returns the username of the user.
 * - getPassword: Returns the password of the user.
 * - getFavorites: Returns the array of favorite items.
 * - getCart: Returns the array of items in the cart.
 * - addToFavorites(isbn): Adds an item to the favorites by ISBN.
 * - removeFav(isbn): Removes an item from the favorites by ISBN.
 * - isFav(isbn): Checks if an item is in the favorites by ISBN.
 * - addToCart(isbn): Adds an item to the favorites by ISBN.
 * - removeFromCart(isbn): Removes an item from the favorites by ISBN.
 * - clearCart(isbn): Checks if an item is in the favorites by ISBN.
 * - toJSON(): Returns the user data as a stringified object.
 */
class User {
	#_username;
	#_password;
	#_favorites = [];
	#_cart = [];

	constructor(data) {
		if (!data)
			return ;
		this.#_username = data.username;
		this.#_password = data.password;
		this.#_favorites = data.favorites;
		this.#_cart = data.cart;
	}

	get getUsername() {
		return this.#_username;
	}

	get getPassword() {
		return this.#_password;
	}

	get getFavorites() {
		return this.#_favorites;
	}

	get getCart() {
		return this.#_cart;
	}

	addToFavorites(isbn) {
		this.#_favorites.push({ ISBN: isbn });
	}

	removeFav(isbn) {
		this.#_favorites = this.#_favorites.filter((list) => list.ISBN !== isbn);
	}

	isFav(isbn) {
		if (this.#_favorites.some((list) => list.ISBN.includes(isbn)))
			return (true);
		return (false);
	}

	addToCart(isbn) {
		let cartItem = this.#_cart.find((list) => list.ISBN.includes(isbn));
		if (cartItem) cartItem.quantidade = cartItem.quantidade + 1;
		else {
			this.#_cart.push({ ISBN: isbn, quantidade: 1});
		}
	}

	removeFromCart(isbn) {
		let cartItem = this.#_cart.find((list) => list.ISBN.includes(isbn));
		if (cartItem) cartItem.quantidade = cartItem.quantidade - 1;
		if (cartItem.quantidade == 0)
			this.#_cart = this.#_cart.filter((list) => list.ISBN !== isbn);
	}

	clearCart() {
		this.#_cart = [];
	}

	toJSON() {
		return JSON.stringify({
			username: this.getUsername,
			password: this.getPassword,
			favorites: this.getFavorites,
			cart: this.getCart
		});
	}
}

if (!localStorage.getItem("userList")) {
	localStorage.setItem("userList", JSON.stringify([]));
}

if (!localStorage.getItem("bestSellers")) {
	localStorage.setItem("bestSellers", JSON.stringify([]));
}

let userList = JSON.parse(localStorage.getItem("userList"));
let bestSellers = JSON.parse(localStorage.getItem("bestSellers"));
let utilizador = new User();
let cardListArray = [];
let cardListIterator = 0;
let uniqueCats = ["Selecionar", "Favoritos ★", "Best-sellers"];
let selectedCat = "";

/** Updates the data I want to save in local storage. This will save userList and bestSellers. */
function updateLocalStorage() {
	let i = 0;
	let data;
	while (i < userList.length)
	{
		data = JSON.parse(userList[i]);
		if (data.username == utilizador.getUsername && data.password == utilizador.getPassword)
			break ;
		i++;
	}
	userList[i] = utilizador.toJSON();
	localStorage.setItem("userList", JSON.stringify(userList));
	localStorage.setItem("bestSellers", JSON.stringify(bestSellers));
}

/** Gets every unique category from DB and assigns the newly created array
 * to global array uniqueCats. */
function getUniqueCats() {
	const categorias = db.map((list) => list.categoria);
	uniqueCats.push(...new Set(categorias));
}

/** Builds category selector. */
function buildCatSelector() {
	const page = document.getElementById("lista-cursos");
	const catSelectorDiv = document.createElement("div");
	catSelectorDiv.setAttribute("id", "select-cat-div");
	catSelectorDiv.setAttribute("class", "select-cat-div");
	const catSelector = document.createElement("select");
	catSelector.setAttribute("id", "select-cat");
	catSelector.setAttribute("onchange", "sortByCat()");
	let catOption;
	let i = 0;
	while (i < uniqueCats.length) {
		catOption = document.createElement("option");
		catOption.setAttribute("value", uniqueCats[i]);
		catOption.textContent = uniqueCats[i].charAt(0).toUpperCase() + uniqueCats[i].slice(1);
		catSelector.appendChild(catOption);
		i++;
	}
	catSelectorDiv.appendChild(catSelector);
	button = document.createElement("button");
	button.setAttribute("id", "clear-filter-button");
	button.setAttribute("onclick", "clearFilter()");
	button.setAttribute("style", "float: right");
	button.textContent = "Limpar filtro";
	catSelectorDiv.appendChild(button);
	page.appendChild(catSelectorDiv);
}

/** Creates an array of elements based on the selected category and updates the page. */
function sortByCat() {
	selectedCat = document.getElementById("select-cat").value;
	let sortedArray = [];
	if (selectedCat == "Favoritos ★")
	{
		let i = 0;
		let favorites = utilizador.getFavorites;
		while (i < favorites.length) {
			sortedArray.push(db.find((list) => list.ISBN.includes(favorites[i].ISBN)));
			i++;
		}
	}
	else if (selectedCat == "Best-sellers") {
		let i = 0;
		while (i < bestSellers.length && i < 5) {
			sortedArray.push(db.find((list) => list.ISBN.includes(bestSellers[i].ISBN)));
			i++;
		}
	}
	else
		sortedArray = db.filter((list) => list.categoria === selectedCat);
	createCardListArray(sortedArray);
	buildPage();
}

/** Clears selected category and updates the page back to default. */
function clearFilter() {
	selectedCat = "";
	createCardListArray(Array.from(db));
	buildPage();
}

/** Receives an array to be processed. It will clear our global array cardListArray and assign it new content. */
function createCardListArray(array) {
	let i = 0;
	let tempArray = [];
	cardListArray = [];
	cardListIterator = 0;
	while (i < array.length) {
		if (tempArray.length == 18) {
			cardListArray.push(tempArray);
			tempArray = [];
		}
		tempArray.push(array[i]);
		i++;
	}
	cardListArray.push(tempArray);
}

/** Clears the card list page to be built again. */
function clearPage() {
	const courseList = document.getElementById("lista-cursos");
	if (courseList.childElementCount < 3) return;
	let toDelete = courseList.getElementsByClassName("select-cat-div");
	if (toDelete.length > 0)
		toDelete[0].parentNode.removeChild(toDelete[0]);
	toDelete = courseList.getElementsByClassName("row");
	while (toDelete[0]) toDelete[0].parentNode.removeChild(toDelete[0]);
	toDelete = courseList.getElementsByClassName("pagination");
	toDelete[0].parentNode.removeChild(toDelete[0]);
}

/** Changes the card list page to the selected one. Receives either the page number or an "iterator". */
function changePage(pageTo) {
	if (pageTo == "<<") cardListIterator = 0;
	else if (pageTo == ">>") cardListIterator = cardListArray.length - 1;
	else if (pageTo == "<") {
		if (cardListIterator - 1 >= 0) cardListIterator = cardListIterator - 1;
		else return;
	} else if (pageTo == ">") {
		if (cardListIterator + 1 < cardListArray.length)
			cardListIterator = cardListIterator + 1;
		else return;
	} else cardListIterator = pageTo;
	buildPage();
}

/** Builds the pagination section. */
function buildPagination() {
	const page = document.getElementById("lista-cursos");
	let pagination = document.createElement("div");
	pagination.setAttribute("id", "pagination");
	pagination.classList.add("pagination");
	let node = document.createElement("a");
	node.setAttribute("onclick", `changePage("<<");`);
	node.textContent = `<<`;
	pagination.appendChild(node);
	node = document.createElement("a");
	node.setAttribute("onclick", `changePage("<");`);
	node.textContent = `<`;
	pagination.appendChild(node);
	let startPage = Math.max(0, cardListIterator - Math.floor(5 / 2));
	let endPage = Math.min(cardListArray.length, startPage + 5);
	if (endPage - startPage <= 4) {
		startPage = Math.max(0, endPage - 5);
	}
	while (startPage < endPage) {
		node = document.createElement("a");
		node.setAttribute("href", "#lista-cursos");
		node.setAttribute("onclick", `changePage(${startPage});`);
		if (startPage == cardListIterator) {
			node.setAttribute("class", "active");
		}
		node.textContent = startPage + 1;
		pagination.appendChild(node);
		startPage++;
	}
	node = document.createElement("a");
	node.setAttribute("onclick", `changePage(">");`);
	node.textContent = `>`;
	pagination.appendChild(node);
	node = document.createElement("a");
	node.setAttribute("onclick", `changePage(">>");`);
	node.textContent = `>>`;
	pagination.appendChild(node);
	page.appendChild(pagination);
}

/** If image is a link, it will just return the link, whereas if it is a local image it will also assign it the img directory. */
function isImg(image) {
	let imgDir = "img/";
	if (image.slice(0, 3) == "http")
		imgDir = "";
	return (`${imgDir}${image}`);
}

/** Checks if an item is on sale. If so, returns both the original and the sales price. Else, just the base price. */
function isOnSale(preco, promocao) {
	if (preco == promocao)
		return (`<span class="u-pull-right">${promocao}€</span>`);
	return (`${preco}€ <span class="u-pull-right">${promocao}€</span>`);
}

/** Builds the card list section. */
function buildCardList() {
	const courseList = document.getElementById("lista-cursos");
	let newOuterCard;
	let newCard;
	let dbIterator = 0;
	let newRow = document.createElement("div");
	newRow.classList.add("row");
	while (dbIterator < cardListArray[cardListIterator].length) {
		if (
			courseList.lastElementChild.hasChildNodes() &&
			courseList.lastElementChild.childElementCount == 3
		) {
			newRow = document.createElement("div");
			newRow.classList.add("row");
		}
		newOuterCard = document.createElement("div");
		newOuterCard.classList.add("four");
		newOuterCard.classList.add("columns");
		newCard = document.createElement("div");
		newCard.classList.add("card");
		let priceLine = isOnSale(cardListArray[cardListIterator][dbIterator].preco, cardListArray[cardListIterator][dbIterator].promocao);
		newCard.innerHTML = `<img class="imagen-curso u-full-width" onclick="showInfoCardModal(alt)" src=${isImg(cardListArray[cardListIterator][dbIterator].imagem)} alt="${cardListArray[cardListIterator][dbIterator].ISBN}"/>
			<div class="info-card">
				<h4>${cardListArray[cardListIterator][dbIterator].titulo}</h4>
				<p>${cardListArray[cardListIterator][dbIterator].autor}</p>
				<p>${cardListArray[cardListIterator][dbIterator].rating}<img src="img/estrela.png" /></p>
				<p class="preco">${priceLine}</p>
				<a id="addFavButton" class="u-full-width button-primary button input adicionar-carrinho" ${isFav(cardListArray[cardListIterator][dbIterator].ISBN)}<img src="img/estrela.png" alt="star">
				</a>
				<a id="addCartButton" class="u-full-width button-primary button input adicionar-carrinho" onclick="addToCart('${cardListArray[cardListIterator][dbIterator].ISBN}')">
					Adicionar ao Carrinho
				</a>
			</div>`;
		newOuterCard.appendChild(newCard);
		newRow.appendChild(newOuterCard);
		courseList.appendChild(newRow);
		dbIterator++;
	}
}

/** Updates the header depending on the selected category. */
function changeHeader() {
	const courseList = document.getElementById("lista-cursos");
	if (selectedCat == "")
		courseList.firstElementChild.textContent = "Cursos Online";
	else if (selectedCat == "Favoritos ★")
		courseList.firstElementChild.textContent = "Favoritos ★";
	else if (selectedCat == "Best-sellers")
		courseList.firstElementChild.textContent = "Best-sellers";
	else
		courseList.firstElementChild.textContent =
			"Cursos Online" +
			` sobre ${
				selectedCat.charAt(0).toUpperCase() + selectedCat.slice(1)
			}`;
}

/** Builds the card list based on the dynamically changing values related to the DB. */
function buildPage() {
	buildCart();
	clearPage();
	buildCatSelector();
	buildCardList();
	buildPagination();
	changeHeader();
}

/** Builds the cart by adding new rows to the table in the cart-list div. */
function buildCart() {
	const cartList = document.getElementById("cart-list");
	cartList.innerHTML = "";
	let cart = utilizador.getCart;
	if (cart.length == 0)
		return ;
	let newCartItem;
	let i = 0;
	let obj;
	while (i < cart.length)
	{
		obj = db.find((list) => list.ISBN.includes(cart[i].ISBN));
		newCartItem = document.createElement("tr");
		newCartItem.innerHTML = `<th>
			<img style="width: 100px;" src=${isImg(obj.imagem)} alt="${obj.ISBN}"/>
		</th>
		<th>
			<h4>${obj.titulo}</h4>
		</th>
		<th>
			<p>${obj.promocao}€</p> 
		</th>
		<th>
			<div style="display: flex">
				<p>${cart[i].quantidade}</p>
				<button style="transform: scale(0.8);" onclick="removeFromCart('${obj.ISBN}')">&times;</button>
			</div>
		</th>`;
		cartList.appendChild(newCartItem);
		i++;
	}
}

/** Sorts bestSellers so that the most sold items are always at the start of the array, for easier access. */
function sortBestSellers() {
	let temp;
	let i;
	let j;
	i = 0;
	while (bestSellers[i]) {
		j = 0;
		while (bestSellers[i + j]) {
			if (bestSellers[i].quantidade < bestSellers[i + j].quantidade) {
				temp = bestSellers[i];
				bestSellers[i] = bestSellers[i + j];
				bestSellers[i + j] = temp;
			}
			j++;
		}
		i++;
	}
}

/** Updates bestSellers, sorts it and clears the cart. */
function finishPurchase() {
	if (!authentication() || utilizador.getCart.length == 0)
		return ;
	cart = utilizador.getCart;
	if (!cart)
		return ;
	let i = 0;
	while (i < cart.length)
	{
		let j = 0;
		while (j < bestSellers.length) {
			if (cart[i].ISBN == bestSellers[j].ISBN) {
				bestSellers[i].quantidade = bestSellers[i].quantidade + cart[i].quantidade;
				break ;
			}
			j++;
		}
		if (j == bestSellers.length) {
			bestSellers[j] = { ISBN: cart[i].ISBN, quantidade: cart[i].quantidade};
		}
		i++;
	}
	sortBestSellers();
	clearCart();
	showPopup("Compra efetuada com sucesso!");
}

/** The name says it all. */
function showPopup(message) {
	let popup = document.getElementById("popup");
	// if (popup.style.display == 'block') // com isto, ele não consegue spamar mensagens, mas sem isto ele omite uma segunda mensagem se ela vier demasiado rápido. ex: adicionei aos favs e ao carrinho
	// 	return ;
	popup.innerHTML = message;
	popup.style.display = "block";
	setTimeout(() => {
		popup.style.display = "none";
	}, 2000);
}

/** Adds ISBN to the favorites array in the user object and updates the local storage. */
function addToFav(isbn) {
	if (!authentication())
		return ;
	utilizador.addToFavorites(isbn);
	showPopup("Item adicionado aos favoritos!");
	buildPage();
	if (infoCardModal.style.display == "block") {
		closeInfoCardModal();
		showInfoCardModal(isbn);
	}
	updateLocalStorage();
}

/** Removes ISBN from the favorites array in the user object and updates the local storage. */
function removeFav(isbn) {
	utilizador.removeFav(isbn);
	if (selectedCat == "Favoritos ★")
	{
		let i = 0;
		let favorites = utilizador.getFavorites;
		while (i < favorites.length) {
			favorites[i] = db.find((list) => list.ISBN.includes(favorites[i].ISBN));
			i++;
		}
		createCardListArray(favorites);
	}
	showPopup("Removido dos favoritos!");
	buildPage();
	if (infoCardModal.style.display == "block") {
		closeInfoCardModal();
		showInfoCardModal(isbn);
	}
	updateLocalStorage();
}

/** Checks if item is a favorite or not when building the page. */
function isFav(isbn) {
	if (utilizador.isFav(isbn))
		return ('onclick="removeFav(' + `'` + isbn + `'` + ')">Remover dos Favoritos');
	return ('onclick="addToFav(' + `'` + isbn + `'` + ')">Adicionar aos Favoritos');
}

/** Adds ISBN to the cart array or increments the property "quantidade" if the ISBN was already there. Also updates the local storage. */
function addToCart(isbn) {
	if (!authentication())
		return ;
	utilizador.addToCart(isbn);
	showPopup("Adicionado ao carrinho!");
	buildCart();
	updateLocalStorage();
}

/** Removes ISBN to the cart array or decrements the property "quantidade" if its value is bigger than 1. Also updates the local storage. */
function removeFromCart(isbn) {
	utilizador.removeFromCart(isbn);
	showPopup("Removido do carrinho!");
	buildCart();
	updateLocalStorage();
}

/** Sets the cart array as empty and updates local storage. */
function clearCart() {
	if (utilizador.getCart.length == 0)
		return ;
	utilizador.clearCart();
	showPopup("Carrinho limpo!");
	buildCart();
	updateLocalStorage();
}