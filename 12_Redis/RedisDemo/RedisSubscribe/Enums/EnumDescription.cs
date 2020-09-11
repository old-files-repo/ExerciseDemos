
namespace xxxxx.Human.Resource.Common.Enums
{
    public static class EnumDescription
    {
        public static string GetNationality(this Nationality item)
        {
            switch (item)
            {
                case Nationality.China:
                    return "中国";
                default:
                    return "";
            }
        }

        public static string GetNation(this Nation item)
        {
            switch (item)
            {
                case Nation.HuiNationality:
                    return "回族";
                case Nation.HanNationality:
                    return "汉族";
                case Nation.ZhuangNationality:
                    return "壮族";
                case Nation.ManNationality:
                    return "满族";
                case Nation.MiaoNationality:
                    return "苗族";
                case Nation.UyghurNationality:
                    return "维吾尔族";
                case Nation.YiNationality:
                    return "彝族";
                case Nation.TuJiaNationality:
                    return "土家族";
                case Nation.MongolNationality:
                    return "蒙古族";
                case Nation.TibetanNationality:
                    return "藏族";
                case Nation.BuyeiNationality:
                    return "布依族";
                case Nation.DongNationality:
                    return "侗族";
                case Nation.YaoONationality:
                    return "瑶族";
                case Nation.KoreanNationality:
                    return "朝鲜族";
                case Nation.BaiNationality:
                    return "白族";
                case Nation.HaNiNationality:
                    return "哈尼族";
                case Nation.LiNationality:
                    return "黎族";
                case Nation.KaZakNationality:
                    return "哈萨克族";
                case Nation.DaiNationality:
                    return "傣族";
                case Nation.SheNationality:
                    return "畲族";
                case Nation.LiSuNationality:
                    return "僳僳族";
                case Nation.GeLaoNationality:
                    return "仡佬族";
                case Nation.LaHuNationality:
                    return "拉祜族";
                case Nation.VaNationality:
                    return "佤族";
                case Nation.DongXiangNationality:
                    return "东乡族";
                case Nation.SuiNationality:
                    return "水族";
                case Nation.NaXiNationality:
                    return "纳西族";
                case Nation.QiangNationality:
                    return "羌族";
                case Nation.TuNationality:
                    return "土族";
                case Nation.XiBeNationality:
                    return "锡伯族";
                case Nation.MuLaoNationality:
                    return "仫佬族";
                case Nation.KiRGIZNationality:
                    return "柯尔克孜族";
                case Nation.DAURNationality:
                    return "达斡尔族";
                case Nation.JinGpoNationality:
                    return "景颇族";
                case Nation.SuLarNationality:
                    return "撒拉族";
                case Nation.BlAngNationality:
                    return "布朗族";
                case Nation.MaoNanNationality:
                    return "毛南族";
                case Nation.TanJikNationality:
                    return "塔吉克族";
                case Nation.PuMiNationality:
                    return "普米族";
                case Nation.AChangNationality:
                    return "阿昌族";
                case Nation.NuNationality:
                    return "怒族";
                case Nation.EWenKiNationality:
                    return "鄂温克族";
                case Nation.GinNationality:
                    return "京族";
                case Nation.JiNoNationality:
                    return "基诺族";
                case Nation.DeAngNationality:
                    return "德昂族";
                case Nation.UZBeKNationality:
                    return "乌孜别克族";
                case Nation.RussiansNationality:
                    return "俄罗斯族";
                case Nation.YuGurNationality:
                    return "裕固族";
                case Nation.BaoAnNationality:
                    return "保安族";
                case Nation.MonBaNationality:
                    return "门巴族";
                case Nation.OroQenNationality:
                    return "鄂伦春族";
                case Nation.DerungNationality:
                    return "独龙族";
                case Nation.TaTarNationality:
                    return "塔塔尔族";
                case Nation.HeZhenNationality:
                    return "赫哲族";
                case Nation.LhoBaNationality:
                    return "珞巴族";        
                case Nation.GaoShanNationality:
                    return "高山族";
             
                default:
                    return "";
            } 
        }

        public static string GetStaffState(this StaffState item)
        {
            switch (item)
            {
                case StaffState.在岗:
                    return "在岗";
                case StaffState.返聘:
                    return "返聘";
                case StaffState.劳务派遣:
                    return "劳务派遣";
                case StaffState.实习生:
                    return "实习生";
                case StaffState.见习生:
                    return "见习生";         
                default:
                    return "";
            }
        }

        public static string GetMaritalStatus(this MaritalStatus item)
        {
            switch (item)
            {
                case MaritalStatus.Spinsterhood:
                    return "未婚";
                case MaritalStatus.Divorce:
                    return "离异";
                case MaritalStatus.FirstMarriage:
                    return "初婚";
                case MaritalStatus.Remarry:
                    return "再婚";
                default:
                    return "";
            }
        }

        public static string GetPoliticsStatus(this PoliticsStatus item)
        {
            switch (item)
            {
                case PoliticsStatus.Else:
                    return "其他";
                case PoliticsStatus.PartyMember:
                    return "党员";
                case PoliticsStatus.LeagueMember:
                    return "团员";
                case PoliticsStatus.Masses:
                    return "群众";
                default:
                    return "";
            }
        }

        public static string GetResidenceType(this ResidenceType item)
        {
            switch (item)
            {
                case ResidenceType.City:
                    return "城镇";
                case ResidenceType.Country:
                    return "农村";
               
                default:
                    return "";
            }
        }

        public static string GetEmployeeSex(this EmployeeSex item)
        {
            switch (item)
            {
                case EmployeeSex.男:
                    return "男";
                case EmployeeSex.女:
                    return "女";

                default:
                    return "";
            }
        }

        public static string GetMajor(this Major item)
        {
            switch (item)
            {
                case Major.环检:
                    return "环检";
                case Major.安检:
                    return "安检";
                case Major.安综检:
                    return "安综检";
                case Major.机动:
                    return "机动";
                case Major.综检:
                    return "综检";
                default:
                    return "";
            }
        }

        public static string GetEmployeeType(this EmployeeType item)
        {
            switch (item)
            {
                case EmployeeType.PoliceOfficer:
                    return "警员";
                case EmployeeType.Staff:
                    return "员工";
                default:
                    return "";
            }
        }

        public static string GetAcademicDegree(this AcademicDegree item)
        {
            switch (item)
            {
                case AcademicDegree.A1:
                    return "A1";
                case AcademicDegree.A2:
                    return "A2";
                case AcademicDegree.A3:
                    return "A3";
                case AcademicDegree.B2:
                    return "B2";
                case AcademicDegree.B1:
                    return "B1";
                case AcademicDegree.C1:
                    return "C1";
                case AcademicDegree.C2:
                    return "C2";
                case AcademicDegree.C3:
                    return "C3";
                case AcademicDegree.C4:
                    return "C4";
                case AcademicDegree.D:
                    return "D";
                case AcademicDegree.F:
                    return "F";
                case AcademicDegree.E:
                    return "E";
                case AcademicDegree.M:
                    return "M";
                case AcademicDegree.N:
                    return "N";
                case AcademicDegree.P:
                    return "P";
                default:
                    return "";
            }
        }
    }
}
