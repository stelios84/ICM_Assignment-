

using Domain.Aggregates.OldAR;

namespace Application.Mappers
{
    public class DtoMapper
    {
        public static DTO.BTCDto ToBtcDto(BTC x)
        {
            var dto = new DTO.BTCDto()
            {
                name = x.GetName(),
                hash = x.GetHash(),
                height = x.GetHeight(),
                high_fee_per_kb = x.GetHighFeePerKb(),
                last_fork_hash = x.GetLastForkHash(),
                last_fork_height = x.GetLastForkHeight(),
                latest_url = x.GetLatestUrl(),
                low_fee_per_kb = x.GetLowFeePerKb(),
                medium_fee_per_kb = x.GetMediumFeePerKb(),
                peer_count = x.GetPeerCount().GetValueOrDefault(),
                previous_hash = x.GetPreviousHash(),
                previous_url = x.GetPreviousUrl(),
                time = x.GetTime(),
                unconfirmed_count = x.GetUnconfirmedCount(),
                CreatedAt = x.GetCreatedAt()
            };
            return dto;
        }

        public static BTC ToBtcDomain(DTO.BTCDto current, string _json)
        {
            var dm = new Domain.Aggregates.OldAR.BTC(current.name, current.height, current.hash, current.time,
                current.latest_url, current.previous_hash, current.previous_url, current.peer_count, current.unconfirmed_count,
                current.high_fee_per_kb, current.medium_fee_per_kb, current.low_fee_per_kb, current.last_fork_height, current.last_fork_hash,
                DateTime.Now, _json);

            return dm;
        }


        public static DTO.BtcTest3DTO ToBtcTest3DTO(BTCTest3 x)
        {
            var dto = new DTO.BtcTest3DTO()
            {
                name = x.GetName(),
                hash = x.GetHash(),
                height = x.GetHeight(),
                high_fee_per_kb = x.GetHighFeePerKb().GetValueOrDefault(),
                last_fork_hash = x.GetLastForkHash(),
                last_fork_height = x.GetLastForkHeight().GetValueOrDefault(),
                latest_url = x.GetLatestUrl(),
                low_fee_per_kb = x.GetLowFeePerKb().GetValueOrDefault(),
                medium_fee_per_kb = x.GetMediumFeePerKb().GetValueOrDefault(),
                peer_count = x.GetPeerCount().GetValueOrDefault(),
                previous_hash = x.GetPreviousHash(),
                previous_url = x.GetPreviousUrl(),
                time = x.GetTime(),
                unconfirmed_count = x.GetUnconfirmedCount().GetValueOrDefault(),
                CreatedAt = x.GetCreatedAt()
            };
            return dto;
        }

        public static DTO.DashDTO ToDashDTO(Dash x)
        {
            var dto = new DTO.DashDTO()
            {
                name = x.GetName(),
                hash = x.GetHash(),
                height = x.GetHeight(),
                high_fee_per_kb = x.GetHighFeePerKb(),
                last_fork_hash = x.GetLastForkHash(),
                last_fork_height = x.GetLastForkHeight(),
                latest_url = x.GetLatestUrl(),
                low_fee_per_kb = x.GetLowFeePerKb(),
                medium_fee_per_kb = x.GetMediumFeePerKb(),
                peer_count = x.GetPeerCount().GetValueOrDefault(),
                previous_hash = x.GetPreviousHash(),
                previous_url = x.GetPreviousUrl(),
                time = x.GetTime(),
                unconfirmed_count = x.GetUnconfirmedCount(),
                CreatedAt = x.GetCreatedAt()
            };

            return dto;
        }

        public static DTO.EthDTO ToEthDTO(EthChain x)
        {
            var dto = new DTO.EthDTO()
            {
                name = x.GetName(),
                hash = x.GetHash(),
                height = x.GetHeight(),
                last_fork_hash = x.GetLastForkHash(),
                last_fork_height = x.GetLastForkHeight(),
                latest_url = x.GetLatestUrl(),
                peer_count = x.GetPeerCount(),
                previous_hash = x.GetPreviousHash(),
                previous_url = x.GetPreviousUrl(),
                time = x.GetTime(),
                unconfirmed_count = x.GetUnconfirmedCount(),
                CreatedAt = x.GetCreatedAt(),
                base_fee = x.GetBaseFee(),
                high_gas_price = x.GetHighGasPrice(),
                high_priority_fee = x.GetHighPriorityFee(),
                low_gas_price = x.GetLowGasPrice(),
                low_priority_fee = x.GetLowPriorityFee(),
                medium_gas_price = x.GetMediumGasPrice(),
                medium_priority_fee = x.GetMediumPriorityFee()
            };

            return dto;
        }

        public static DTO.LtcDTO ToLtcDTO(LTC x)
        {
            var dto = new DTO.LtcDTO()
            {
                name = x.GetName(),
                hash = x.GetHash(),
                height = x.GetHeight(),
                last_fork_hash = x.GetLastForkHash(),
                last_fork_height = x.GetLastForkHeight(),
                latest_url = x.GetLatestUrl(),
                peer_count = x.GetPeerCount().GetValueOrDefault(),
                previous_hash = x.GetPreviousHash(),
                previous_url = x.GetPreviousUrl(),
                time = x.GetTime(),
                unconfirmed_count = x.GetUnconfirmedCount(),
                CreatedAt = x.GetCreatedAt(),
                high_fee_per_kb = x.GetHighFeePerKb(),
                low_fee_per_kb = x.GetLowFeePerKb(),
                medium_fee_per_kb = x.GetMediumFeePerKb()
            };

            return dto;
        }
    }
}
