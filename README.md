# IndiciaRepo

Dit is een Proof of Concept voor een configuratie systeem. Het is een WPF (Windows Presentation Foundation) applicatie gemaakt met het .net framework. Het deel waar entity framework in verwerkt zit is terug te vinden in de DAL laag. De UI laag maakt gebruikt van het MVVM (model-view-viewmodel) patroon om zo de UI en business laag gescheiden te houden.
Ik zal even kort toelichten welke plekken het meest interessant zijn en hoe deze applicatie is opgesteld. 



# Business > Rulesets
Dit zijn regels om te kijken of een bepaald model voldoen aan de gesteld eisen.

# Business > Services
Hier worden alle repositories aangeroepen

# DAL (entity framework)
#   Configurations
Aparte database klasse waarin de velden van de database aangegeven worden en welke specificaties ze hebben.
ook worden hier de relaties tussen de tabellen ingezet.

#   Context
De database context waar de connectie met de database ingesteld wordt.
Hier worden ook alle database configuration en modellen opgenomen.

#   Repositories
Spreekt voor zich


