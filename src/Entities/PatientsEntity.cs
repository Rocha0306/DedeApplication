using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DedeApplication.Interfaces;

namespace DedeApplication.Entities
{
    public class PatientsEntity : IPatientEntity
    {
    public string Id {get;set;}
    public string NomePaciente {get;set;}


    public string DataVisita { get; set; }
    public string Saps3 { get; set; }
    public string DihUti { get; set; }
    public string Diagnostico { get; set; }
    public string FerramentasDiagnosticasPendentes { get; set; }
    
    // Nutrição
    public string AporteNutricional { get; set; }
    public string ProgredirDieta { get; set; }
    public string SuspenderDieta { get; set; }
    public string AntiemeticosOuCineticos { get; set; }
    public string EvacuacaoUltimas48h { get; set; }
    public string AjusteNutricional { get; set; }
    
    // Analgesia
    public string Analgesicos { get; set; }
    public string AjusteAnalgesia { get; set; }
    
    // Sedação e Psicotrópicos
    public string Sedacao { get; set; }
    public string RassAlvo { get; set; }
    public string DespertarDiario { get; set; }
    public string Delirium { get; set; }
    public string AjusteSedacao { get; set; }
    
    // Drogas Vasoativas/Inotrópicas
    public string DrogasVasoativas { get; set; }
    public string AjusteDrogasVasoativas { get; set; }
    
    // Profilaxias
    public string ProfilaxiaTEV { get; set; }
    public string ProfilaxiaUlceraEstresse { get; set; }
    public string ProfilaxiaUlceraCornea { get; set; }
    public string MudancaDecubito { get; set; }
    public string AjusteProfilaxias { get; set; }
    
    // Controle Glicêmico
    public string Hipoglicemia { get; set; }
    public string HiperglicemiaMaisDeDoisEpisodios { get; set; }
    public string Insulina24h { get; set; }
    public string AjusteGlicemico { get; set; }
    
    // Distúrbios hidroeletrolíticos
    public string Ira { get; set; }
    public string BalancoHidrico { get; set; }
    public string CorrecaoEletronicos { get; set; }
    public string CriterioUrgenciaHD { get; set; }
    public string ObsDisturbios { get; set; }
    
    // Hemoterapia
    public string Transfusao { get; set; }
    public string TipoTransfusao { get; set; }
    public string ObsHemoterapia { get; set; }
    
    // Antibioticoterapia
    public string Antibiotico { get; set; }
    public string EscalonarAntibiotico { get; set; }
    public string ObsAntibiotico { get; set; }
    
    // Culturas
    public string SolicitarCulturas { get; set; }
    public string TipoCultura { get; set; }
    public string ObsCulturas { get; set; }
    
    // Suspensão de terapias e dispositivos
    public string SuspensaoTerapias { get; set; }
    public string ObsSuspensao { get; set; }
    
    // Exames pendentes
    public string ExamesPendentes { get; set; }
    public string AgendamentoExames { get; set; }
    
    // Especialidades em seguimento
    public string Especialidades { get; set; }
    
    // Cuidados Paliativos
    public string CuidadosPaliativos { get; set; }
    public string FamiliaresCientes { get; set; }
    public string ObsPaliativos { get; set; }
    
    // Alta da UTI
    public string AltaUTI { get; set; }
    
    // Assinatura/Responsável
    public string MedicoDiarista { get; set; }

    public string HospitalName {get;set;} 
    }
}